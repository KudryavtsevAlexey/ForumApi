using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;
using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/organization")]
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
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If organization not found</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrganizationByName([FromRoute] int id)
        {
            var organization = await _serviceManager.OrganizationService.GetOrganizationById(id);

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
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If organization users not found</response>
        [HttpGet]
        [Route("{id}/users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrganizationUsers([FromRoute] int id)
        {
            var organizationUsers = await _serviceManager.OrganizationService.GetOrganizationUsers(id);

            if (organizationUsers is null)
            {
                return NotFound();
            }

            return Ok(organizationUsers);
        }

        /// <summary>
        /// Creates organization
        /// </summary>
        /// <returns>No content if organization created</returns>
        /// <response code="204">If organization created</response>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganizationDto organizationDto)
        {
	        await _serviceManager.OrganizationService.CreateOrganization(organizationDto);

	        return NoContent();
        }

        /// <summary>
        /// Updates organization
        /// </summary>
        /// <returns>No content if organization updated</returns>
        /// <response code="204">If organization updated</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If organization not found</response>
        [HttpPatch]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrganization([FromBody]UpdateOrganizationDto organizationDto)
        {
            await _serviceManager.OrganizationService.UpdateOrganization(organizationDto);

            return NoContent();
        }

        /// <summary>
        /// Deletes organization
        /// </summary>
        /// <returns>No content if organization deleted</returns>
        /// <response code="204">If organization deleted</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If organization not found</response>
        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOrganization([FromRoute]int id)
        {
            await _serviceManager.OrganizationService.DeleteOrganization(id);

            return NoContent();
        }
    }
}
