using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/listing")]
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
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If listings not found</response>
        [HttpGet]
        [Route("published")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If listings not found</response>
        [HttpGet]
        [Route("published/by-category")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedListingsByCategory([FromQuery]string category)
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
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If listing not found</response>
        [HttpGet]
        [Route("find/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListingById([FromQuery]int id)
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
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If listings not found</response>
        [HttpGet]
        [Route("by-date")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        /// <response code="401">If user not authorized</response>
        /// <responde code="404">if listings not found</responde>
        [HttpGet]
        [Route("find/userId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListingsByUserId([FromQuery]int id)
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
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If listing not found</response>
        [HttpGet]
        [Route("find/userId/published")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedListingsByUserId([FromQuery]int id)
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
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If listings not found</response>
        [HttpGet]
        [Route("find/userId/unpublished")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnpublishedListingsByUserId([FromQuery]int id)
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
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If listing not found</response>
        [HttpGet]
        [Route("published/find/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedListingById([FromQuery]int id)
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
        /// <returns>Ok if listing created</returns>
        /// <responde code="201">Returns ok if article added</responde>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateListing([FromBody]CreateListingDto listing)
        {
            await _serviceManager.ListingService.CreateListing(listing);

            return Ok(listing);
        }

        /// <summary>
        /// Updates listing
        /// </summary>
        /// <returns>Ok if listing updated</returns>
        /// <response code="200">Returns ok if listing updated</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If listing not found</response>
        [HttpPatch]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateListing([FromQuery]int id, [FromBody]UpdateListingDto listing)
        {
            await _serviceManager.ListingService.UpdateListing(id, listing);

            return Ok(listing);
        }

        /// <summary>
        /// Deletes listing
        /// </summary>
        /// <returns>Ok if listing deleted</returns>
        /// <response code="200">If user deleted</response>
        /// <response code="404">If user not found</response>
        [HttpDelete]
        [Route("{id}/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteListing([FromRoute]int id)
        {
            await _serviceManager.ListingService.DeleteListing(id);

            return Ok();
        }
    }
}
