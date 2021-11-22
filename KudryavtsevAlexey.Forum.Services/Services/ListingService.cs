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
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    internal sealed class ListingService : IListingService
    {
        private readonly ForumDbContext _dbContext;

        public ListingService(ForumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddListing(Listing listing)
        {
            if (listing is null)
            {
                throw new ArgumentNullException(nameof(listing));
            }

            await _dbContext.Listings.AddAsync(listing);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Listing> GetListingById(int id)
        {
            var listing = await _dbContext.Listings.FindAsync(id);

            if (listing is null)
            {
                throw new ListingNotFoundException(id);
            }

            return listing;
        }

        public async Task<List<Listing>> GetPublishedListings()
        {
            return await _dbContext.Listings.Where(l => l.PublishedAt != null)
                .ToListAsync();
        }

        public async Task<List<Listing>> GetPublishedListingsByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                throw new ArgumentNullException(nameof(category));    
            }

            return await _dbContext.Listings.Where(l => l.Category == category)
                .Where(l => l.PublishedAt != null)
                .ToListAsync();
        }

        public async Task<List<Listing>> SortListingsByDate()
        {
            return await _dbContext.Listings.OrderByDescending(l => l.PublishedAt)
                .ToListAsync();
        }

        public async Task UpdateListing(Listing listing)
        {
            if (listing is null)
            {
                throw new ArgumentNullException(nameof(listing));
            }

            _dbContext.Listings.Update(listing);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ListingMainComment>> GetComments()
        {
            return await _dbContext.ListingMainComments
                .Include(c => c.SubComments)
                .ToListAsync();
        }
    }
}
