using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using Microsoft.AspNetCore.Authorization;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
	[ApiController]
    [Authorize]
    [Route("api/article")]
    public class ArticleController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ArticleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Returns article by id
        /// </summary>
        /// <returns>Article</returns>
        /// <response code="200">Returns article</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If article not found</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticleById([FromRoute]int id)
        {
            var article = await _serviceManager.ArticleService.GetArticleById(id);

            return Ok(article);
        }

        /// <summary>
        /// Returns list of the published articles
        /// </summary>
        /// <returns>Published articles</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("all/published")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedArticles()
        {
            var articles = await _serviceManager.ArticleService.GetPublishedArticles();

            if (articles.Count == 0)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns list of the articles sorted by date
        /// </summary>
        /// <returns>Articles sorted by date</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("all/newest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSortedArticlesByDate()
        {
            var articles = await _serviceManager.ArticleService.SortArticlesByDate();

            if (articles.Count == 0)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns published article by id
        /// </summary>
        /// <returns>Published article by id</returns>
        /// <response code="200">Returns article</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If article not found</response>
        [HttpGet]
        [Route("published/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedArticleById([FromRoute]int id)
        {
            var article = await _serviceManager.ArticleService.GetPublishedArticleById(id);

            return Ok(article);
        }

        /// <summary>
        /// Returns published articles by user
        /// </summary>
        /// <returns>Published articles by user</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("all/user/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticlesByUserId([FromRoute]int id)
        {
            var articles = await _serviceManager.ArticleService.GetArticlesByUserId(id);

            if (articles.Count == 0)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns unpublished articles by user
        /// </summary>
        /// <returns>Unpublished articles by user</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("published/user/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedArticlesByUserId([FromRoute]int id)
        {
            var articles = await _serviceManager.ArticleService.GetPublishedArticlesByUserId(id);

            if (articles.Count == 0)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns unpublished articles by user
        /// </summary>
        /// <returns>Unpublished articles by user</returns>
        /// <response code="200">Returns articles</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If articles not found</response>
        [HttpGet]
        [Route("unpublished/user/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnpublishedArticlesByUserId([FromRoute]int id)
        {
            var articles = await _serviceManager.ArticleService.GetUnpublishedArticlesByUserId(id);

            if (articles.Count == 0)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Adds article
        /// </summary>
        /// <returns>No content if article created</returns>
        /// <response code="204">If article created</response>
        /// <response code="401">If user not authorized</response>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateArticle([FromBody]CreateArticleDto articleDto)
        {
            await _serviceManager.ArticleService.CreateArticle(articleDto);

            return NoContent();
        }

        /// <summary>
        /// Updates article
        /// </summary>
        /// <returns>No content if article updated</returns>
        /// <response code="204">If article updated</response>
        /// <response code="401">If user not authorized</response>
        [HttpPatch]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateArticle([FromBody]UpdateArticleDto articleDto)
        {
            await _serviceManager.ArticleService.UpdateArticle(articleDto);

            return NoContent();
        }

        /// <summary>
        /// Deletes article
        /// </summary>
        /// <returns>No content if article deleted</returns>
        /// <response code="204">If article deleted</response>
        /// <response code="401">If user not authorized</response>
        /// <response code="404">If user not found</response>
        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArticle([FromRoute]int id)
        {
            await _serviceManager.ArticleService.DeleteArticle(id);

            return NoContent();
        }
        
    }
}
