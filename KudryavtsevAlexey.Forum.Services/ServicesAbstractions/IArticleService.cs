using KudryavtsevAlexey.Forum.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IArticleService
    {
        public Task<List<ArticleDto>> GetPublishedArticles();

        public Task CreateArticle(ArticleToCreateDto articleDto);

        public Task<List<ArticleDto>> SortArticlesByDate();

        public Task<ArticleDto> GetArticleById(int id);

        public Task<List<ArticleDto>> GetArticlesByUserId(int id);

        public Task<List<ArticleDto>> GetPublishedArticlesByUserId(int id);

        public Task<List<ArticleDto>> GetUnpublishedArticlesByUserId(int id);

        public Task UpdateArticle(int id, ArticleToUpdateDto articleDto);

        public Task<ArticleDto> GetPublishedArticleById(int id);
    }
}
