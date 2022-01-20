using KudryavtsevAlexey.Forum.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
	public interface IArticleService
    {
        public Task<List<ArticleDto>> GetPublishedArticles();

        public Task<List<ArticleDto>> SortArticlesByDate();

        public Task<ArticleDto> GetArticleById(int articleId);

        public Task<ArticleDto> GetPublishedArticleById(int articleId);

        public Task<List<ArticleDto>> GetArticlesByUserId(int userId);

        public Task<List<ArticleDto>> GetPublishedArticlesByUserId(int userId);

        public Task<List<ArticleDto>> GetUnpublishedArticlesByUserId(int userId);

        public Task CreateArticle(CreateArticleDto articleDto);

        public Task UpdateArticle(UpdateArticleDto articleDto);

        public Task DeleteArticle(int articleId);
    }
}
