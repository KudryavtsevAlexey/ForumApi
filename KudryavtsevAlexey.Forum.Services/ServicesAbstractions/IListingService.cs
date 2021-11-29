using KudryavtsevAlexey.Forum.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using KudryavtsevAlexey.Forum.Services.Dtos;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IListingService
    {
        public Task<List<ListingDto>> GetPublishedListings();

        public Task AddListing(ListingDto listing);

        public Task<List<ListingDto>> SortListingsByDate();

        public Task<ListingDto> GetListingById(int id);

        public Task<List<ListingDto>> GetListingsByUserId(int id);

        public Task<List<ListingDto>> GetPublishedListingsByCategory(string category);

        public Task<List<ListingDto>> GetPublishedListingsByUserId(int id);

        public Task<List<ListingDto>> GetUnpublishedListingsByUserId(int id);

        public Task UpdateListing(ListingDto listing);

        public Task<ListingDto> GetPublishedListingById(int id);
    }
}
