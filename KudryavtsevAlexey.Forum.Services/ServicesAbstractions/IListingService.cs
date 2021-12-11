using KudryavtsevAlexey.Forum.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IListingService
    {
        public Task<List<ListingDto>> GetPublishedListings();

        public Task<List<ListingDto>> SortListingsByDate();

        public Task<ListingDto> GetPublishedListingById(int listingId);

        public Task<ListingDto> GetListingById(int listingId);

        public Task<List<ListingDto>> GetListingsByUserId(int userId);

        public Task<List<ListingDto>> GetPublishedListingsByCategory(string category);

        public Task<List<ListingDto>> GetPublishedListingsByUserId(int userId);

        public Task<List<ListingDto>> GetUnpublishedListingsByUserId(int userId);

        public Task CreateListing(CreateListingDto listingDto);

        public Task UpdateListing(int listingId, UpdateListingDto listingDto);

        public Task DeleteListing(int listingId);
    }
}
