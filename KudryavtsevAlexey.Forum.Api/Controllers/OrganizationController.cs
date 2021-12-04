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
    [Route("api/organizations")]
    public class OrganizationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OrganizationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Returns organization by name
        /// </summary>
        /// <returns>Organization</returns>
        /// <response code="200">Returns organization</response>
        /// <response code="404">If organization not found</response>
        [HttpGet]
        [Route("{organizationName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrganizationByName(string organizationName)
        {
            var organization = await _serviceManager.OrganizationService.GetOrganizationByName(organizationName);

            if (organization is null)
            {
                return NotFound();
            }

            return Ok(organization);
        }

        /// <summary>
        /// Returns organization users
        /// </summary>
        /// <returns>Organization users</returns>
        /// <response code="200">Returns users</response>
        /// <response code="404">If organization users not found</response>
        [HttpGet]
        [Route("{organizationName}/users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrganizationUsers(string organizationName)
        {
            var organizationUsers = await _serviceManager.OrganizationService.GetOrganizationUsers(organizationName);

            if (organizationUsers is null)
            {
                return NotFound();
            }

            return Ok(organizationUsers);
        }

        /// <summary>
        /// Returns organization articles
        /// </summary>
        /// <returns>Organization articles</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="404">If organization articles not found</response>
        [HttpGet]
        [Route("{organizationName}/articles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrganizationArticles(string organizationName)
        {
            var organizationArticles = await _serviceManager.OrganizationService.GetOrganizationArticles(organizationName);

            if (organizationArticles is null)
            {
                return NotFound();
            }

            return Ok(organizationArticles);
        }

        /// <summary>
        /// Returns organization listings
        /// </summary>
        /// <returns>Organization listings</returns>
        /// <response code="200">Returns listing</response>
        /// <response code="404">If organization listings not found</response>
        [HttpGet]
        [Route("{organizationName}/listings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrganizationListings(string organizationName)
        {
            var organizationListings = await _serviceManager.OrganizationService.GetOrganizationListings(organizationName);

            if (organizationListings is null)
            {
                return NotFound();
            }

            return Ok(organizationListings);
        }
    }
}
