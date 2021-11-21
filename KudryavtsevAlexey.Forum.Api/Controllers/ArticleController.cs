using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("published")]
        public async Task<IActionResult> GetPublishedArticles()
        {
            var articles = await _serviceManager.ArticleService.GetPublishedArticles();

            if (articles == null)
            {
                return NotFound();
            }

            return Ok(articles);
        }
    }
}
