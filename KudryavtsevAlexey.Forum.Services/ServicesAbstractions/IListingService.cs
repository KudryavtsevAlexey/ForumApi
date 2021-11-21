using KudryavtsevAlexey.Forum.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IListingService
    {
        public Task<List<Listing>> GetPublishedListings();

        public Task AddListing(Listing listing);

        public Task<List<Listing>> SortListingsByDate();

        public Task<List<Listing>> GetPublishedListingsByCategory(string category);

        public Task<Listing> GetListingById(int id);

        public Task UpdateListing(Listing listing);

        public Task<List<ListingMainComment>> GetComments();
    }
}
