using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    internal sealed class ListingService : IListingService
    {
        private readonly ForumDbContext _dbContext;

        private readonly IMapper _mapper;

        public ListingService(ForumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ListingDto> GetListingById(int listingId)
        {
            var listing = await _dbContext.Listings
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == listingId);

            if (listing is null)
            {
                throw new ListingNotFoundException(listingId);
            }

            var listingDto = _mapper.Map<ListingDto>(listing);

            return listingDto;
        }

        public async Task<List<ListingDto>> GetListingsByUserId(int userId)
        {
            var userListings = await _dbContext.Listings
                .Where(x => x.UserId == userId)
                .Include(x=>x.Tags)
                .ToListAsync();

            var userListingsDtos = _mapper.Map<List<ListingDto>>(userListings);

            return userListingsDtos;
        }

        public async Task<List<ListingDto>> GetPublishedListings()
        {
            var publishedListings =  await _dbContext.Listings.Where(l => l.PublishedAt != null)
                .ToListAsync();

            var publishedListingsDtos = _mapper.Map<List<ListingDto>>(publishedListings);

            return publishedListingsDtos;
        }

        public async Task<List<ListingDto>> GetPublishedListingsByCategory(string category)
        {
            var listingsByCategory = await _dbContext.Listings.Where(l => l.Category.ToLower() == category.ToLower())
                .Where(l => l.PublishedAt != null)
                .ToListAsync();

            var listingsByCategoryDtos = _mapper.Map<List<ListingDto>>(listingsByCategory);

            return listingsByCategoryDtos;
        }

        public async Task<List<ListingDto>> GetPublishedListingsByUserId(int userId)
        {
            var userPublishedListings = await _dbContext.Listings
                .Where(x => x.UserId == userId)
                .Where(x => x.PublishedAt != null)
                .ToListAsync();

            var userPublishedListingsDtos = _mapper.Map<List<ListingDto>>(userPublishedListings);

            return userPublishedListingsDtos;
        }

        public async Task<List<ListingDto>> GetUnpublishedListingsByUserId(int userId)
        {
            var userPublishedListings = await _dbContext.Listings
                .Where(x => x.UserId == userId)
                .Where(x => x.PublishedAt == null)
                .ToListAsync();

            var userPublishedListingsDtos = _mapper.Map<List<ListingDto>>(userPublishedListings);

            return userPublishedListingsDtos;
        }

        public async Task<List<ListingDto>> SortListingsByDate()
        {
            var listingsByDate =  await _dbContext.Listings.OrderByDescending(l => l.PublishedAt)
                .ToListAsync();

            var listingsByDateDtos = _mapper.Map<List<ListingDto>>(listingsByDate);

            return listingsByDateDtos;
        }

        public async Task<ListingDto> GetPublishedListingById(int listingId)
        {
            var publishedListing = await _dbContext.Listings.FirstOrDefaultAsync(x => x.Id == listingId);

            if (publishedListing is null)
            {
                throw new ListingNotFoundException(listingId);
            }

            var publishedListingDto = _mapper.Map<ListingDto>(publishedListing);

            return publishedListingDto;
        }

        public async Task CreateListing(CreateListingDto listingDto)
        {
            var listing = _mapper.Map<Listing>(listingDto);

            var tags = await _dbContext.Tags.ToListAsync();
            int[] identifiers = tags.Select(x => x.Id).ToArray();

            if (!(listingDto.Tags is null))
            {
                listing.Tags = new List<Tag>();
                for (int i = 0; i < listingDto.Tags.Count; i++)
                {
                    if (identifiers.Contains(listingDto.Tags[i].Id))
                    {
                        int tagId = listingDto.Tags[i].Id;
                        tags[tagId - 1].Listings = new List<Listing>() { listing };
                        listing.Tags.Add(tags[tagId - 1]);
                    }
                }
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == listingDto.UserId);

            if (user is null)
            {
                throw new UserNotFoundException(listingDto.UserId);
            }

            var organization = await _dbContext.Organizations
	            .FirstOrDefaultAsync(x => x.Id == user.OrganizationId);

            if (organization is null)
            {
	            throw new OrganizationNotFoundException(user.OrganizationId);
            }

            listing.UserId = user.Id;
            listing.User = user;

            user.Listings.Add(listing);

            await _dbContext.Listings.AddAsync(listing);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateListing(UpdateListingDto listingDto)
        {
            var listingToUpdating = await _dbContext.Listings
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == listingDto.Id);

            if (listingToUpdating is null)
            {
                throw new ArticleNotFoundException(listingDto.Id);
            }

            listingToUpdating.Title = listingDto.Title;
            listingToUpdating.ShortDescription = listingDto.ShortDescription;

            var tags = await _dbContext.Tags.ToListAsync();
            int[] identifiers = tags.Select(x => x.Id).ToArray();

            if (!(listingToUpdating.Tags is null))
            {
                listingToUpdating.Tags = new List<Tag>();
                for (int i = 0; i < listingDto.Tags.Count; i++)
                {
                    if (identifiers.Contains(listingDto.Tags[i].Id))
                    {
                        int tagId = listingDto.Tags[i].Id;
                        tags[tagId - 1].Listings = new List<Listing>() { listingToUpdating };
                        listingToUpdating.Tags.Add(tags[tagId - 1]);
                    }
                }
            }

            _dbContext.Listings.Update(listingToUpdating);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteListing(int listingId)
        {
            var listing = await _dbContext.Listings.FirstOrDefaultAsync(x => x.Id == listingId);

            if (listing is null)
            {
                throw new ListingNotFoundException(listingId);
            }

            _dbContext.Listings.Remove(listing);
            await _dbContext.SaveChangesAsync();
        }
    }
}
