using KudryavtsevAlexey.Forum.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dto;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IArticleService
    {
        public Task<List<Article>> GetPublishedArticles();

        public Task AddArticle(ArticleDto article);

        public Task<List<Article>> SortArticlesByDate();

        public Task<Article> GetArticleById(int id);

        public Task<List<Article>> GetArticlesByUser(User user);

        public Task<List<Article>> GetPublishedArticlesByUser(User user);

        public Task<List<Article>> GetUnpublishedArticlesByUser(User user);

        public Task UpdateArticle(ArticleDto article);

        public Task<Article> GetPublishedArticleById(int id);
    }
}
