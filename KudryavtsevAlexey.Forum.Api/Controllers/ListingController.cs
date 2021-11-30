using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos;
using Microsoft.AspNetCore.Identity;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Route("api/listings")]
    public class ListingController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ListingController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Returns published listings
        /// </summary>
        /// <returns>Published listings</returns>
        /// <response code="200">Returns listings</response>
        /// <response code="404">If listings not found</response>
        [HttpGet]
        [Route("published")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedListings()
        {
            var listings = await _serviceManager.ListingService.GetPublishedListings();

            if (listings is null)
            {
                return NotFound();
            }

            return Ok(listings);
        }

        /// <summary>
        /// Returns published listings by category
        /// </summary>
        /// <returns>Listings by category</returns>
        /// <response code="200">Returns listings</response>
        /// <response code="404">If listings not found</response>
        [HttpGet]
        [Route("published/{category}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedListingsByCategory(string category)
        {
            var publishedListingsByCategory = await _serviceManager.ListingService.GetPublishedListingsByCategory(category);

            if (publishedListingsByCategory is null)
            {
                return NotFound();
            }

            return Ok(publishedListingsByCategory);
        }

        /// <summary>
        /// Returns listing by id
        /// </summary>
        /// <returns>Listing by id</returns>
        /// <response code="200">Returns listing</response>
        /// <response code="404">If listing not found</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListingById(int id)
        {
            var listing = await _serviceManager.ListingService.GetListingById(id);

            if (listing is null)
            {
                return NotFound();
            }

            return Ok(listing);
        }

        /// <summary>
        /// Returns listings sorted by date
        /// </summary>
        /// <returns>Listings sorted by date</returns>
        /// <response code="200">Returns sorted listings</response>
        /// <response code="404">If listings not found</response>
        [HttpGet]
        [Route("by-date")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SortListingsByDate()
        {
            var listings = await _serviceManager.ListingService.SortListingsByDate();

            if (listings is null)
            {
                return NotFound();
            }

            return Ok(listings);
        }

        /// <summary>
        /// Returns listings by user id
        /// </summary>
        /// <returns>Listings by user id</returns>
        /// <response code="200">Returns listings</response>
        /// <responde code="404">if listings not found</responde>
        [HttpGet]
        [Route("{user{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListingsByUserId(int id)
        {
            var listings = await _serviceManager.ListingService.GetListingsByUserId(id);

            if (listings is null)
            {
                return NotFound();
            }

            return Ok(listings);
        }

        /// <summary>
        /// Returns published listing by id
        /// </summary>
        /// <returns>Published listing by id</returns>
        /// <response code="200">Returns listing</response>
        /// <response code="404">If listing not found</response>
        [HttpGet]
        [Route("user/{id}/published")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedListingsByUserId(int id)
        {
            var listings = await _serviceManager.ListingService.GetPublishedListingById(id);

            if (listings is null)
            {
                return NotFound();
            }

            return Ok(listings);
        }

        /// <summary>
        /// Returns unpublished listing by user id
        /// </summary>
        /// <returns>Unpublished listing by user id</returns>
        /// <response code="200">Returns listings</response>
        /// <response code="404">If listings not found</response>
        [HttpGet]
        [Route("user/{id}/unpublished")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnpublishedListingsByUserId(int id)
        {
            var listings = await _serviceManager.ListingService.GetUnpublishedListingsByUserId(id);

            if (listings is null)
            {
                return NotFound();
            }

            return Ok(listings);
        }

        /// <summary>
        /// Returns published listing by id
        /// </summary>
        /// <returns>Published listing by id</returns>
        /// <response code="200">Returns listing</response>
        /// <response code="404">If listing not found</response>
        [HttpGet]
        [Route("published/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedListingById(int id)
        {
            var listing = await _serviceManager.ListingService.GetPublishedListingById(id);

            if (listing is null)
            {
                return NotFound();
            }

            return Ok(listing);
        }
        
        /// <summary>
        /// Adds listing
        /// </summary>
        /// <returns>Ok if listing added</returns>
        /// <responde code="201">Returns ok if article added</responde>
        [HttpPost]
        [Route("creating")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Createlisting(ListingDto listing)
        {
            await _serviceManager.ListingService.AddListing(listing);

            return Ok(listing);
        }

        /// <summary>
        /// Updates listing
        /// </summary>
        /// <returns>Ok if listing updated</returns>
        /// <response code="200">Returns ok if listing updated</response>
        /// <response code="404">If listing not found</response>
        [HttpPut]
        [Route("updating")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateListing(int id, ListingDto listing)
        {
            await _serviceManager.ListingService.UpdateListing(id, listing);

            return Ok(listing);
        }
    }
}
