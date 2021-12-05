using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _serviceManager.UserService.GetUserById(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
        /// <summary>
        /// Returns user subscribers
        /// </summary>
        /// <returns>User subscribers</returns>
        /// <response code="200">Returns subscribers</response>>
        /// <response code="404">If subscribers not found</response>
        [HttpGet]
        [Route("user/{id}/subscribers")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserSubscribers(int id)
        {
            var subscribers = await _serviceManager.UserService.GetUserSubscribers(id);

            if (subscribers is null)
            {
                return NotFound();
            }

            return Ok(subscribers);
        }
    }
}
