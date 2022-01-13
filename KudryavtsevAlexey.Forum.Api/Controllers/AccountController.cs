using System;
using System.Net;
using System.Net.Http;
using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AccountController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Returns no content if user registered
        /// </summary>
        /// <returns>No content if user registered</returns>
        /// <response code="204">Returns no content</response>
        [HttpPost]
        [Route("registration")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Register([FromBody]RegisterUserDto userDto)
        {
            await _serviceManager.AccountService.Register(userDto);

            return NoContent();
        }

        /// <summary>
        /// Returns no content if user signed in
        /// </summary>
        /// <returns>No content if user signed in</returns>
        /// <response code="204">Returns no content</response>
        [HttpPost]
        [Route("sign-in")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn([FromBody]SignInUserDto userDto)
        {
            var token = await _serviceManager.AccountService.SignIn(userDto);

            if (string.IsNullOrEmpty(token))
            {
	            return BadRequest();
            }

            return NoContent();
        }

        /// <summary>
        /// Returns no content if user signed out
        /// </summary>
        /// <returns>No content if user signed out</returns>
        /// <response code="204">Returns no content</response>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("sign-out")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Logout()
        {
            await _serviceManager.AccountService.SignOut();

            return NoContent();
        }

        /// <summary>
        /// Returns no content if user deleted
        /// </summary>
        /// <returns>No content if user deleted</returns>
        /// <response code="204">Returns no content</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If user not found</response>
        [HttpDelete]
        [Route("{id}/delete")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAccount([FromRoute]int id)
        {
            await _serviceManager.AccountService.DeleteUser(id);

            return NoContent();
        }
    }
}
