using KudryavtsevAlexey.Forum.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IArticleService
    {
        public Task<List<Article>> GetPublishedArticles();

        public Task AddArticle(Article article);

        public Task<List<Article>> SortArticlesByDate();

        public Task<Article> GetArticleById(int id);

        public Task<List<Article>> GetArticlesByUser(User user);

        public Task<List<Article>> GetPublishedArticlesByUser(User user);

        public Task<List<Article>> GetUnpublishedArticlesByUser(User user);

        public Task UpdateArticle(Article article);

        public Task<Article> GetPublishedArticleById(int id);
    }
}
