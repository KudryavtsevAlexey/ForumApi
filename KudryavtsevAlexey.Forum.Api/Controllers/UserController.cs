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
    [Authorize]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Returns user by id
        /// </summary>
        /// <returns>Ok if user found</returns>
        /// <response code="200">If user found</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If user not found</response>
        [HttpGet]
        [Route("find/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById([FromQuery]int id)
        {
            var user = await _serviceManager.UserService.GetUserById(id);

            return Ok(user);
        }

        /// <summary>
        /// Returns user subscribers
        /// </summary>
        /// <returns>User subscribers</returns>
        /// <response code="200">Returns subscribers</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If subscribers not found</response>
        [HttpGet]
        [Route("find/userId/subscribers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserSubscribers([FromQuery]int id)
        {
            var subscribers = await _serviceManager.UserService.GetUserSubscribers(id);

            if (subscribers.Count == 0)
            {
                return NotFound();
            }

            return Ok(subscribers);
        }

        /// <summary>
        /// Creates subscriber
        /// </summary>
        /// <returns>No content if subscriber created</returns>
        /// <response code="204">If subscriber created</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If user or subscriber not found</response>
		[HttpPost]
		[Route("sub")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SubscribeUser([FromQuery] int userId, [FromQuery] int subscriberId)
		{
			await _serviceManager.UserService.CreateSubscriber(userId, subscriberId);

			return NoContent();
		}

        /// <summary>
        /// Deletes subscriber
        /// </summary>
        /// <returns>No content if subscriber deleted</returns>
        /// <response code="204">If subscriber deleted</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If subscriber user or subscriber not found</response>
        [HttpDelete]
		[Route("unsub")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> StopSubscribe([FromQuery] int userId, [FromQuery] int subscriberId)
		{
			await _serviceManager.UserService.DeleteSubscriber(userId, subscriberId);

			return NoContent();
		}

        /// <summary>
        /// Updates user
        /// </summary>
        /// <returns>No content if user updated</returns>
        /// <response code="204">If user updated</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If user not found</response>
        [HttpPatch]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser([FromRoute]int id, [FromBody]UpdateApplicationUserDto userDto)
        {
            await _serviceManager.UserService.UpdateUser(id, userDto);

            return NoContent();
        }
    }
}
