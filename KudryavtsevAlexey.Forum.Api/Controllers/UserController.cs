using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Returns user subscribers
        /// </summary>
        /// <returns>User subscribers</returns>
        /// <response code="200">Returns subscribers</response>>
        /// <response code="404">If subscribers not found</response>
        [HttpGet]
        [Route("user/{id}/subscribers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
