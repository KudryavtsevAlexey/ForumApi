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
        /// Returns ok if user registered
        /// </summary>
        /// <returns>Ok if user registered</returns>
        /// <response code="201">Returns ok</response>
        [HttpPost]
        [Route("registration")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(RegisterUserDto userDto)
        {
            await _serviceManager.AccountService.Register(userDto);

            return Ok();
        }

        /// <summary>
        /// Returns ok if user signed in
        /// </summary>
        /// <returns>Ok if user signed in</returns>
        /// <response code="200">Returns ok</response>
        [HttpPost]
        [Route("sign-in")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SignIn(SignInUserDto userDto)
        {
            var token = await _serviceManager.AccountService.SignIn(userDto);

            return Ok(token);
        }

        /// <summary>
        /// Returns ok if user signed out
        /// </summary>
        /// <returns>Ok if user signed out</returns>
        /// <response code="200">Returns ok</response>
        [HttpPost]
        [Route("sign-out")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout()
        {
            await _serviceManager.AccountService.SignOut();

            return Ok();
        }

        /// <summary>
        /// Returns ok if user deleted
        /// </summary>
        /// <returns>Ok if user deleted</returns>
        /// <response code="200">Returns ok</response>
        /// <response code="404">If user not found</response>
        [HttpDelete]
        [Route("delete")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceManager.AccountService.DeleteUser(id);

            return Ok();
        }
    }
}
