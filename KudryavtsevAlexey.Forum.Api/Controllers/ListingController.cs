using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        
    }
}
