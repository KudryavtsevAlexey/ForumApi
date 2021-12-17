using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "JwtBearer")]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("find/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById([FromQuery]int id)
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
        [Route("find/userId/subscribers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserSubscribers([FromQuery]int id)
        {
            var subscribers = await _serviceManager.UserService.GetUserSubscribers(id);

            if (subscribers is null)
            {
                return NotFound();
            }

            return Ok(subscribers);
        }

        /// <summary>
        /// Updates user
        /// </summary>
        /// <returns>Ok if user updated</returns>
        /// <response code="200">If user updated</response>
        /// <response code="404">If user not found</response>
        [HttpPatch]
        [Route("updating")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser([FromRoute]int id, [FromBody]UpdateApplicationUserDto userDto)
        {
            await _serviceManager.UserService.UpdateUser(id, userDto);

            return Ok();
        }
    }
}
