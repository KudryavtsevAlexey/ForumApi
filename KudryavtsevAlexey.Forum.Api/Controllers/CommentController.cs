using KudryavtsevAlexey.Forum.Services.ServiceManager;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using Microsoft.AspNetCore.Authorization;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/comment")]
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

            if (comments.Count == 0)
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

            if (comments.Count == 0)
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

            if (allArticleComments.Count == 0)
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

            if (allListingComments.Count == 0)
            {
                return NotFound();
            }

            return Ok(allListingComments);
        }

        /// <summary>
        /// Creates comment to article
        /// </summary>
        /// <returns>No content if comment created</returns>
        /// <response code="204">If comment created</response>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("article-comment/create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateArticleMainComment([FromBody]CreateArticleMainCommentDto articleMainCommentDto)
        {
            await _serviceManager.CommentService.CreateArticleMainComment(articleMainCommentDto);

            return NoContent();
        }

        /// <summary>
        /// Creates comment to listing
        /// </summary>
        /// <returns>No content if comment created</returns>
        /// <response code="204">If comment created</response>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("listing-comment/create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateListingMainComment([FromBody]CreateListingMainCommentDto listingMainCommentDto)
        {
            await _serviceManager.CommentService.CreateListingMainComment(listingMainCommentDto);

            return NoContent();
        }

        /// <summary>
        /// Creates subcomment to article
        /// </summary>
        /// <returns>No content if comment created</returns>
        /// <response code="204">If subcomment created</response>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("article-subcomment/create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateArticleSubComment([FromBody]CreateArticleSubCommentDto articleSubCommentDto)
        {
            await _serviceManager.CommentService.CreateArticleSubComment(articleSubCommentDto);

            return NoContent();
        }

        /// <summary>
        /// Creates subcomment to listing
        /// </summary>
        /// <returns>No content if comment created</returns>
        /// <response code="204">If subcomment created</response>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("listing-subcomment/create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateListingSubComment([FromBody]CreateListingSubCommentDto listingSubCommentDto)
        {
            await _serviceManager.CommentService.CreateListingSubComment(listingSubCommentDto);

            return NoContent();
        }

        /// <summary>
        /// Updates comment to article
        /// </summary>
        /// <returns>No content if comment updated</returns>
        /// <response code="204">If comment updated</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comment not found</response>
        [HttpPatch]
        [Route("article-comment/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateArticleMainComment([FromBody]UpdateArticleMainCommentDto articleMainCommentDto)
        {
            await _serviceManager.CommentService.UpdateArticleMainComment(articleMainCommentDto);

            return NoContent();
        }

        /// <summary>
        /// Updates comment to listing
        /// </summary>
        /// <returns>No content if comment updated</returns>
        /// <response code="204">If comment updated</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comment not found</response>
        [HttpPatch]
        [Route("listing-comment/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateListingMainComment([FromBody]UpdateListingMainCommentDto listingMainCommentDto) 
        {
            await _serviceManager.CommentService.UpdateListingMainComment(listingMainCommentDto);

            return NoContent();
        }

        /// <summary>
        /// Updates subcomment to article
        /// </summary>
        /// <returns>No content if subcomment updated</returns>
        /// <response code="204">If subcomment updated</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If subcomment not found</response>
        [HttpPatch]
        [Route("article-subcomment/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateArticleSubComment([FromBody]UpdateArticleSubCommentDto articleSubCommentDto)
        {
            await _serviceManager.CommentService.UpdateArticleSubComment(articleSubCommentDto);

            return NoContent();
        }

        /// <summary>
        /// Updates subcomment to listing
        /// </summary>
        /// <returns>No content if subcomment updated</returns>
        /// <response code="204">If subcomment updated</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If subcomment not found</response>
        [HttpPatch]
        [Route("listing-subcomment/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateListingSubComment([FromBody]UpdateListingSubCommentDto listingSubCommentDto)
        {
            await _serviceManager.CommentService.UpdateListingSubComment(listingSubCommentDto);

            return NoContent();
        }

        /// <summary>
        /// Deletes comment to article
        /// </summary>
        /// <returns>No content if comment deleted</returns>
        /// <response code="204">If comment deleted</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comment not found</response>
        [HttpDelete]
        [Route("article-comment/{id}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArticleMainComment([FromRoute]int id)
        {
            await _serviceManager.CommentService.DeleteArticleMainComment(id);

            return NoContent();
        }

        /// <summary>
        /// Deletes comment to listing
        /// </summary>
        /// <returns>No content if comment deleted</returns>
        /// <response code="204">If comment deleted</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If comment not found</response>
        [HttpDelete]
        [Route("listing-comment/{id}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteListingMainComment([FromRoute]int id)
        {
            await _serviceManager.CommentService.DeleteListingMainComment(id);

            return NoContent();
        }

        /// <summary>
        /// Deletes subcomment to article
        /// </summary>
        /// <returns>No content if subcomment deleted</returns>
        /// <response code="204">If subcomment deleted</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If subcomment not found</response>
        [HttpDelete]
        [Route("article-subcomment/{id}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArticleSubComment([FromRoute]int id)
        {
            await _serviceManager.CommentService.DeleteArticleSubComment(id);

            return NoContent();
        }

        /// <summary>
        /// Deletes subcomment to listing
        /// </summary>
        /// <returns>No content if subcomment deleted</returns>
        /// <response code="204">If subcomment deleted</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If subcomment not found</response>
        [HttpDelete]
        [Route("listing-subcomment/{id}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteListingSubComment([FromRoute]int id)
        {
            await _serviceManager.CommentService.DeleteListingSubComment(id);

            return NoContent();
        }
    }
}
