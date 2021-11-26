using KudryavtsevAlexey.Forum.Services.ServiceManager;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
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
        /// <param name="id"></param>
        /// <returns>Comments to article</returns>
        /// <response code="200">Returns comments</response>
        /// <response code="404">If comments not found</response>
        [HttpGet]
        [Route("article/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticleComments(ArticleDto article)
        {
            var comments = await _serviceManager.CommentService.GetArticleComments(article);

            if (comments is null)
            {
                return NotFound();
            }

            return Ok(comments);
        }

        /// <summary>
        /// Returns comments to listing
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Comments to listing</returns>
        /// <response code="200">Returns comments</response>
        /// <response code="404">If comments not found</response>
        [HttpGet]
        [Route("listing/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListingComments(ListingDto listing)
        {
            var comments = await _serviceManager.CommentService.GetListingComments(listing);

            if (comments is null)
            {
                return NotFound();
            }

            return Ok(comments);
        }

        /// <summary>
        /// Returns comment to article by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Comment to article by id</returns>
        /// <response code="200">Returns comment</response>
        /// <response code="404">If comment not found</response>
        [HttpGet]
        [Route("article-comment/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticleMainCommentById(int id)
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
        /// <param name="id"></param>
        /// <returns>Comment to listing by id</returns>
        /// <response code="200">Returns comment</response>
        /// <response code="404">If comment not found</response>
        [HttpGet]
        [Route("listing-comment/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListingMainCommentById(int id)
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
        /// <param name="id"></param>
        /// <returns>Subcomment to article by id</returns>
        /// <response code="200">Returns subcomment</response>
        /// <response code="404">If subcomment not found</response>
        [HttpGet]
        [Route("article-subcomment/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticleSubCommentById(int id)
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
        /// <param name="id"></param>
        /// <returns>Subcomment to listing by id</returns>
        /// <response code="200">Returns subcomment</response>
        /// <response code="404">If subcomment not found</response>
        [HttpGet]
        [Route("listing-subcomment/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListingSubCommentById(int id)
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
        /// <response code="404">If comments not found</response>
        [HttpGet]
        [Route("articles/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        /// <response code="404">If comments not found</response>
        [HttpGet]
        [Route("listings/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllListingComments()
        {
            var allListingComments = await _serviceManager.CommentService.GetAllListingsComments();

            if (allListingComments is null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
