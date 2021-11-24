using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.ServiceManager;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.MappingHelpers;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticleController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ArticleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Returns list of the published articles
        /// </summary>
        /// <returns>Published articles</returns>
        /// <produce code="200">Returns articles</produce>
        /// <produce code="404">If articles not found</produce>
        [HttpGet]
        [Route("published")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedArticles()
        {
            var articles = await _serviceManager.ArticleService.GetPublishedArticles();

            if (articles is null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns list of the articles sorted by date
        /// </summary>
        /// <returns>Articles sorted by date</returns>
        /// <produce code="200">Returns articles</produce>
        /// <produce code="404">If articles not found</produce>
        [HttpGet]
        [Route("sorted")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSortedArticlesByDate()
        {
            var articles = await _serviceManager.ArticleService.SortArticlesByDate();

            if (articles is null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns published article by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Published article by id</returns>
        /// <produce code="200">Returns article</produce>
        /// <produce code="404">If article not found</produce>
        [HttpGet]
        [Route("published/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedArticleById(int id)
        {
            var article = await _serviceManager.ArticleService.GetPublishedArticleById(id);

            if (article is null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        /// <summary>
        /// Returns published articles by user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Published articles by user</returns>
        /// <produce code="200">Returns articles</produce>
        /// <produce code="404">If articles not found</produce>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticlesByUser(int id)
        {
            var user = await _serviceManager.UserService.GetUserById(id);

            var articles = await _serviceManager.ArticleService.GetPublishedArticlesByUser(user);

            if (articles is null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns unpublished articles by user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Unpublished articles by user</returns>
        /// <produce code="200">Returns articles</produce>
        /// <produce code="404">If articles not found</produce>
        [HttpGet]
        [Route("{id}/published")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublishedArticlesByUser(int id)
        {
            var user = await _serviceManager.UserService.GetUserById(id);

            var articles = await _serviceManager.ArticleService.GetPublishedArticlesByUser(user);

            if (articles is null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns unpublished articles by user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Unpublished articles by user</returns>
        /// <produce code="200">Returns articles</produce>
        /// <produce code="404">If articles not found</produce>
        [HttpGet]
        [Route("{id}/unpublished")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnpublishedArticlesByUser(int id)
        {
            var user = await _serviceManager.UserService.GetUserById(id);

            var articles = await _serviceManager.ArticleService.GetUnpublishedArticlesByUser(user);

            if (articles is null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Returns all articles by user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>All articles by user</returns>
        /// <produce code="200">Returns articles</produce>
        /// <produce code="404">If articles not found</produce>
        [HttpGet]
        [Route("{id}/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllArticlesByUser(int id)
        {
            var user = await _serviceManager.UserService.GetUserById(id);

            var articles = await _serviceManager.ArticleService.GetArticlesByUser(user);

            if (articles is null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        /// <summary>
        /// Adds article
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///{
        ///    "title": "Title20",
        ///    "shortDescription": "ShortDesctiption20",
        ///    "organizationId" : "1",
        ///
        ///    "organization": {
        ///        "Id" : "1",
        ///        "imageUrl": "ProfileImages\\ProfileImage.png",
        ///        "organizationId" : "1",
        ///        "organization": {
        ///            "organizationId" : "1",
        ///        }, 
        ///        "imageUrl": "ProfileImages\\ProfileImage.png",
        ///    },
        ///
        ///    "userId" : "1",
        ///    "user" : {
        ///        "Id" : "1",
        ///        },
        ///    },
        ///    "publishedAt": "2021-11-24T09:24:08.088Z",
        ///},

        /// 
        /// </remarks>
        /// <produce code="201">Returns ok when article added</produce>
        [HttpPost]
        [Route("creating")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateArticle([FromBody]ArticleDto article)
        {
            await _serviceManager.ArticleService.AddArticle(article);

            return Ok(article);
        }

        /// <summary>
        /// Updates article
        /// </summary>
        /// <param name="article"></param>
        /// <produce code="200">Returns ok when article updated</produce>
        [HttpPut]
        [Route("updating")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateArticle(ArticleDto article)
        {
            await _serviceManager.ArticleService.UpdateArticle(article);

            return Ok(article);
        }
    }
}
