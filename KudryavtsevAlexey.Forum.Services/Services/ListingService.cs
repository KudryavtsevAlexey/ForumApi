using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using KudryavtsevAlexey.Forum.Services.Dtos;

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

        public async Task AddListing(ListingDto listing)
        {
            if (listing is null)
            {
                throw new ArgumentNullException(nameof(listing));
            }

            var listingToAdding = _mapper.Map<Listing>(listing);

            try
            {
                await _dbContext.Listings.AddAsync(listingToAdding);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ListingExists(listingToAdding.Id).GetAwaiter().GetResult())
            {
                // TODO: ILogger
            }
        }

        public async Task<ListingDto> GetListingById(int id)
        {
            var listing = await _dbContext.Listings.FirstOrDefaultAsync(x=>x.Id == id);

            if (listing is null)
            {
                throw new ListingNotFoundException(id);
            }

            var listingDto = _mapper.Map<ListingDto>(listing);

            return listingDto;
        }

        public async Task<List<ListingDto>> GetListingsByUserId(int id)
        {
            var userListings = await _dbContext.Listings
                .Where(x => x.UserId == id)
                .ToListAsync();

            if (userListings is null)
            {
                throw new ListingsNotFoundException();
            }

            var userListingsDtos = _mapper.Map<List<ListingDto>>(userListings);

            return userListingsDtos;
        }

        public async Task<List<ListingDto>> GetPublishedListings()
        {
            var publishedListings =  await _dbContext.Listings.Where(l => l.PublishedAt != null)
                .ToListAsync();

            if (publishedListings is null)
            {
                throw new ListingsNotFoundException();
            }

            var publishedListingsDtos = _mapper.Map<List<ListingDto>>(publishedListings);

            return publishedListingsDtos;
        }

        public async Task<List<ListingDto>> GetPublishedListingsByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                throw new ArgumentNullException(nameof(category));    
            }

            var listingsByCategory = await _dbContext.Listings.Where(l => l.Category == category)
                .Where(l => l.PublishedAt != null)
                .ToListAsync();

            if (listingsByCategory is null)
            {
                throw new ListingsNotFoundException();
            }

            var listingsByCategoryDtos = _mapper.Map<List<ListingDto>>(listingsByCategory);

            return listingsByCategoryDtos;
        }

        public async Task<List<ListingDto>> GetPublishedListingsByUserId(int id)
        {
            var userPublishedListings = await _dbContext.Listings
                .Where(x => x.UserId == id)
                .Where(x => x.PublishedAt != null)
                .ToListAsync();

            if (userPublishedListings is null)
            {
                throw new ListingsNotFoundException();
            }

            var userPublishedListingsDtos = _mapper.Map<List<ListingDto>>(userPublishedListings);

            return userPublishedListingsDtos;
        }

        public async Task<List<ListingDto>> GetUnpublishedListingsByUserId(int id)
        {
            var userPublishedListings = await _dbContext.Listings
                .Where(x => x.UserId == id)
                .Where(x => x.PublishedAt == null)
                .ToListAsync();

            if (userPublishedListings is null)
            {
                throw new ListingsNotFoundException();
            }

            var userPublishedListingsDtos = _mapper.Map<List<ListingDto>>(userPublishedListings);

            return userPublishedListingsDtos;
        }

        public async Task<List<ListingDto>> SortListingsByDate()
        {
            var listingsByDate =  await _dbContext.Listings.OrderByDescending(l => l.PublishedAt)
                .ToListAsync();

            if (listingsByDate is null)
            {
                throw new ListingsNotFoundException();
            }

            var listingsByDateDtos = _mapper.Map<List<ListingDto>>(listingsByDate);

            return listingsByDateDtos;
        }

        public async Task UpdateListing(ListingDto listing)
        {
            if (listing is null)
            {
                throw new ArgumentNullException(nameof(listing));
            }

            var listingToUpdating = _mapper.Map<Listing>(listing);

            try
            {
                _dbContext.Listings.Update(listingToUpdating);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ListingExists(listingToUpdating.Id).GetAwaiter().GetResult())
            {
                // TODO: ILogger
            }
        }

        public async Task<ListingDto> GetPublishedListingById(int id)
        {
            var publishedListing = await _dbContext.Listings.FirstOrDefaultAsync(x => x.Id == id);

            if (publishedListing is null)
            {
                throw new ListingNotFoundException(id);
            }

            var publishedListingDto = _mapper.Map<ListingDto>(publishedListing);

            return publishedListingDto;
        }

        private async Task<bool> ListingExists(int id)
        {
            return await _dbContext.Listings.AnyAsync(a => a.Id == id);
        }
    }
}
