using KudryavtsevAlexey.Forum.Services.ServiceManager;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using Microsoft.AspNetCore.Authorization;
using Azure;
using Microsoft.Identity.Client;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "JwtBearer")]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CommentController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Returns comments to article
        /// </summary>
        /// <returns>Comments to article</returns>
        /// <response code="200">Returns comments</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comments not found</response>
        [HttpGet]
        [Route("article/find/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticleComments([FromQuery]int id)
        {
            var comments = await _serviceManager.CommentService.GetArticleComments(id);

            if (comments is null)
            {
                return NotFound();
            }

            return Ok(comments);
        }

        /// <summary>
        /// Returns comments to listing
        /// </summary>
        /// <returns>Comments to listing</returns>
        /// <response code="200">Returns comments</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comments not found</response>
        [HttpGet]
        [Route("listing/find/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListingComments([FromQuery]int id)
        {
            var comments = await _serviceManager.CommentService.GetListingComments(id);

            if (comments is null)
            {
                return NotFound();
            }

            return Ok(comments);
        }

        /// <summary>
        /// Returns comment to article by id
        /// </summary>
        /// <returns>Comment to article by id</returns>
        /// <response code="200">Returns comment</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comment not found</response>
        [HttpGet]
        [Route("article-comment/find/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticleMainCommentById([FromQuery]int id)
        {
            var articleMainComment = await _serviceManager.CommentService.GetArticleMainCommentById(id);

            if (articleMainComment is null)
            {
                return NotFound();
            }

            return Ok(articleMainComment);
        }

        /// <summary>
        /// Returns comment to listing by id
        /// </summary>
        /// <returns>Comment to listing by id</returns>
        /// <response code="200">Returns comment</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comment not found</response>
        [HttpGet]
        [Route("listing-comment/find/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListingMainCommentById([FromQuery]int id)
        {
            var listingMainComment = await _serviceManager.CommentService.GetListingMainCommentById(id);

            if (listingMainComment is null)
            {
                return NotFound();
            }

            return Ok(listingMainComment);
        }

        /// <summary>
        /// Returns subcomment to article by id
        /// </summary>
        /// <returns>Subcomment to article by id</returns>
        /// <response code="200">Returns subcomment</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If subcomment not found</response>
        [HttpGet]
        [Route("article-subcomment/find/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticleSubCommentById([FromQuery]int id)
        {
            var articleSubComment = await _serviceManager.CommentService.GetArticleSubCommentById(id);

            if (articleSubComment is null)
            {
                return NotFound();
            }

            return Ok(articleSubComment);
        }

        /// <summary>
        /// Returns subcomment to listing by id
        /// </summary>
        /// <returns>Subcomment to listing by id</returns>
        /// <response code="200">Returns subcomment</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If subcomment not found</response>
        [HttpGet]
        [Route("listing-subcomment/find/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListingSubCommentById([FromQuery]int id)
        {
            var listingSubComment = await _serviceManager.CommentService.GetListingSubCommentById(id);

            if (listingSubComment is null)
            {
                return NotFound();
            }

            return Ok(listingSubComment);
        }

        /// <summary>
        /// Returns all comments to articles
        /// </summary>
        /// <returns>All comments to articles</returns>
        /// <response code="200">Returns comments</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comments not found</response>
        [HttpGet]
        [Route("articles/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllArticleComments()
        {
            var allArticleComments = await _serviceManager.CommentService.GetAllArticlesComments();

            if (allArticleComments is null)
            {
                return NotFound();
            }

            return Ok(allArticleComments);
        }

        /// <summary>
        /// Returns all comments to listings
        /// </summary>
        /// <returns>All comments to listings</returns>
        /// <response code="200">Returns comments</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comments not found</response>
        [HttpGet]
        [Route("listings/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllListingComments()
        {
            var allListingComments = await _serviceManager.CommentService.GetAllListingsComments();

            if (allListingComments is null)
            {
                return NotFound();
            }

            return Ok(allListingComments);
        }

        /// <summary>
        /// Creates comment to article
        /// </summary>
        /// <returns>Ok if comment created</returns>
        /// <response code="201">If comment created</response>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("article-comment/creating")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateArticleMainComment([FromBody]CreateArticleMainCommentDto articleMainCommentDto)
        {
            await _serviceManager.CommentService.CreateArticleMainComment(articleMainCommentDto);

            return Ok();
        }

        /// <summary>
        /// Creates comment to listing
        /// </summary>
        /// <returns>Ok if comment created</returns>
        /// <response code="201">If comment created</response>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("listing-comment/creating")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateListingMainComment([FromBody]CreateListingMainCommentDto listingMainCommentDto)
        {
            await _serviceManager.CommentService.CreateListingMainComment(listingMainCommentDto);

            return Ok();
        }

        /// <summary>
        /// Creates subcomment to article
        /// </summary>
        /// <returns>Ok if comment created</returns>
        /// <response code="201">If subcomment created</response>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("article-subcomment/creating")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateArticleSubComment([FromBody]CreateArticleSubCommentDto articleSubCommentDto)
        {
            await _serviceManager.CommentService.CreateArticleSubComment(articleSubCommentDto);

            return Ok();
        }

        /// <summary>
        /// Creates subcomment to listing
        /// </summary>
        /// <returns>Ok if comment created</returns>
        /// <response code="201">If subcomment created</response>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("listing-subcomment/creating")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateListingSubComment([FromBody]CreateListingSubCommentDto listingSubCommentDto)
        {
            await _serviceManager.CommentService.CreateListingSubComment(listingSubCommentDto);

            return Ok();
        }

        /// <summary>
        /// Updates comment to article
        /// </summary>
        /// <returns>Ok if comment updated</returns>
        /// <response code="200">If comment updated</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comment not found</response>
        [HttpPatch]
        [Route("article-comment/updating")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateArticleMainComment([FromQuery]int id, [FromBody]UpdateArticleMainCommentDto articleMainCommentDto)
        {
            await _serviceManager.CommentService.UpdateArticleMainComment(id, articleMainCommentDto);

            return Ok();
        }

        /// <summary>
        /// Updates comment to listing
        /// </summary>
        /// <returns>Ok if comment updated</returns>
        /// <response code="200">If comment updated</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comment not found</response>
        [HttpPatch]
        [Route("listing-comment/updating")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateListingMainComment([FromQuery]int id, [FromBody]UpdateListingMainCommentDto listingMainCommentDto) 
        {
            await _serviceManager.CommentService.UpdateListingMainComment(id, listingMainCommentDto);

            return Ok();
        }

        /// <summary>
        /// Updates subcomment to article
        /// </summary>
        /// <returns>Ok if subcomment updated</returns>
        /// <response code="200">If subcomment updated</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If subcomment not found</response>
        [HttpPatch]
        [Route("article-subcomment/updating")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateArticleSubComment([FromQuery]int id, [FromBody]UpdateArticleSubCommentDto articleSubCommentDto)
        {
            await _serviceManager.CommentService.UpdateArticleSubComment(id, articleSubCommentDto);

            return Ok();
        }

        /// <summary>
        /// Updates subcomment to listing
        /// </summary>
        /// <returns>Ok if subcomment updated</returns>
        /// <response code="200">If subcomment updated</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If subcomment not found</response>
        [HttpPatch]
        [Route("listing-subcomment/updating")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateListingSubComment([FromQuery]int id, [FromBody]UpdateListingSubCommentDto listingSubCommentDto)
        {
            await _serviceManager.CommentService.UpdateListingSubComment(id, listingSubCommentDto);

            return Ok();
        }

        /// <summary>
        /// Deletes comment to article
        /// </summary>
        /// <returns>Ok if comment deleted</returns>
        /// <response code="200">If comment deleted</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comment not found</response>
        [HttpDelete]
        [Route("article-comment/{id}/deleting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArticleMainComment([FromRoute]int id)
        {
            await _serviceManager.CommentService.DeleteArticleMainComment(id);

            return Ok();
        }

        /// <summary>
        /// Deletes comment to listing
        /// </summary>
        /// <returns>Ok if comment deleted</returns>
        /// <response code="200">If comment deleted</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comment not found</response>
        [HttpDelete]
        [Route("listing-comment/{id}/deleting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteListingMainComment([FromRoute]int id)
        {
            await _serviceManager.CommentService.DeleteListingMainComment(id);

            return Ok();
        }

        /// <summary>
        /// Deletes subcomment to article
        /// </summary>
        /// <returns>Ok if subcomment deleted</returns>
        /// <response code="200">If subcomment deleted</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If subcomment not found</response>
        [HttpDelete]
        [Route("article-subcomment/{id}/deleting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArticleSubComment([FromRoute]int id)
        {
            await _serviceManager.CommentService.DeleteArticleSubComment(id);

            return Ok();
        }

        /// <summary>
        /// Deletes subcomment to listing
        /// </summary>
        /// <returns>Ok if subcomment deleted</returns>
        /// <response code="200">If subcomment deleted</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If subcomment not found</response>
        [HttpDelete]
        [Route("listing-subcomment/{id}/deleting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteListingSubComment([FromRoute]int id)
        {
            await _serviceManager.CommentService.DeleteListingSubComment(id);

            return Ok();
        }
    }
}
