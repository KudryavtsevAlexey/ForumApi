using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Authorization;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "JwtBearer")]
    [Route("api/tags")]
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
        public async Task<IActionResult> GetTagById(int id)
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
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _serviceManager.TagService.GetAllTags();

            return Ok(tags);
        }

        /// <summary>
        /// Creates tag
        /// </summary>
        /// <returns>Ok if tag created</returns>
        /// <response code="200">Returns ok</response>
        [HttpPost]
        [Route("creating")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateTag(CreateTagDto tagDto)
        {
            await _serviceManager.TagService.CreateTag(tagDto);

            return Ok();
        }

        /// <summary>
        /// Updates tag
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns ok if tag updated</response>
        /// <response code="404">If tag not found</response>
        [HttpPatch]
        [Route("updating")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTag(int id, UpdateTagDto tagDto)
        {
            await _serviceManager.TagService.UpdateTag(id, tagDto);

            return Ok();
        }

        /// <summary>
        /// Deletes tag
        /// </summary>
        /// <returns>Ok if tag deleted</returns>
        /// <response code="200">Returns ok</response>
        /// <response code="404">If tag not found</response>
        [HttpDelete]
        [Route("deleting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _serviceManager.TagService.DeteteTag(id);

            return Ok();
        }
    }
}
