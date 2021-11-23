using KudryavtsevAlexey.Forum.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IArticleService
    {
        public Task<List<ArticleDto>> GetPublishedArticles();

        public Task AddArticle(ArticleDto article);

        public Task<List<ArticleDto>> SortArticlesByDate();

        public Task<Article> GetArticleById(int id);

        public Task<List<ArticleDto>> GetArticlesByUser(User user);

        public Task<List<ArticleDto>> GetPublishedArticlesByUser(User user);

        public Task<List<ArticleDto>> GetUnpublishedArticlesByUser(User user);

        public Task UpdateArticle(ArticleDto article);

        public Task<ArticleDto> GetPublishedArticleById(int id);
    }
}
