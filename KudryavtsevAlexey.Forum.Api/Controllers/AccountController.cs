using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        [AllowAnonymous]
        [HttpPost]
        [Route("registration")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(RegisterUserDto userDto)
        {
            var token = await _serviceManager.AccountService.Register(userDto);

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("sign-in")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> SignIn(SignInUserDto userDto)
        {
            var token = await _serviceManager.AccountService.SignIn(userDto);

            return Ok(token);
        }
    }
}
