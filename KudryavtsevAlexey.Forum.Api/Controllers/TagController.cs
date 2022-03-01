using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Authorization;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/tag")]
    public class TagController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TagController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Returns tag by id
        /// </summary>
        /// <returns>Tag by id</returns>
        /// <response code="200">Returns tag</response>
        /// <response code="404">If tag not found</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTagById([FromRoute]int id)
        {
            var tag = await _serviceManager.TagService.GetTagById(id);

            return Ok(tag);
        }

        /// <summary>
        /// Returns all tags
        /// </summary>
        /// <returns>All tags</returns>
        /// <response code="200">Returns tags</response>
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _serviceManager.TagService.GetAllTags();

            if (tags.Count == 0)
            {
	            return NotFound();
            }

            return Ok(tags);
        }

        /// <summary>
        /// Creates tag
        /// </summary>
        /// <returns>No content if tag created</returns>
        /// <response code="204">If tag created</response>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateTag([FromBody]CreateTagDto tagDto)
        {
            await _serviceManager.TagService.CreateTag(tagDto);

            return NoContent();
        }

        /// <summary>
        /// Updates tag
        /// </summary>
        /// <returns>No content if tag updated</returns>
        /// <response code="204">If tag updated</response>
        /// <response code="404">If tag not found</response>
        [HttpPatch]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTag([FromBody]UpdateTagDto tagDto)
        {
            await _serviceManager.TagService.UpdateTag(tagDto);

            return NoContent();
        }

        /// <summary>
        /// Deletes tag
        /// </summary>
        /// <returns>No content if tag deleted</returns>
        /// <response code="204">If tag deleted</response>
        /// <response code="404">If tag not found</response>
        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTag([FromRoute]int id)
        {
            await _serviceManager.TagService.DeleteTag(id);

            return NoContent();
        }
    }
}
