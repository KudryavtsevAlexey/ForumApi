using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.MappingHelpers;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    internal sealed class ArticleService : IArticleService
    {
        private readonly ForumDbContext _dbContext;
        private readonly IMappingHelper<ArticleDto, Article> _mappingHelper;

        public ArticleService(ForumDbContext dbContext, IMappingHelper<ArticleDto, Article> mappingHelper)
        {
            _dbContext = dbContext;
            _mappingHelper = mappingHelper;
        }

        public async Task AddArticle(ArticleDto article)
        {
            if (article is null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            var articleToAdding = _mappingHelper.MapModelToSecondType(article);

            await _dbContext.Articles.AddAsync(articleToAdding);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Article> GetArticleById(int id)
        {
            var article = await _dbContext.Articles.FirstOrDefaultAsync(a=>a.Id == id);

            if (article is null)
            {
                throw new ArticleNotFoundException(id);
            }

            return article;
        }

        public async Task<List<ArticleDto>> GetArticlesByUser(User user)
        {
            var articles = await _dbContext.Articles.Where(a => a.User == user)
                .ToListAsync();

            if (articles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var articleDtos = _mappingHelper.MapListModelsToFirstType(articles);

            return articleDtos;
        }

        public async Task<List<ArticleDto>> GetPublishedArticles()
        {
            var articles = await _dbContext.Articles.Where(a => a.PublishedAt != null)
                .ToListAsync();

            if (articles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var articleDtos = _mappingHelper.MapListModelsToFirstType(articles);

            return articleDtos;
        }

        public async Task<List<ArticleDto>> GetPublishedArticlesByUser(User user)
        {
            var articles = await _dbContext.Articles.Where(a => a.User == user)
                .Where(a=>a.PublishedAt!=null)
                .ToListAsync();

            if (articles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var articleDtos = _mappingHelper.MapListModelsToFirstType(articles);

            return articleDtos;
        }

        public async Task<List<ArticleDto>> GetUnpublishedArticlesByUser(User user)
        {
            var articles = await _dbContext.Articles.Where(a => a.User == user)
                .Where(a => a.PublishedAt == null)
                .ToListAsync();

            if (articles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var articleDtos = _mappingHelper.MapListModelsToFirstType(articles);

            return articleDtos;
        }

        public async Task<List<ArticleDto>> SortArticlesByDate()
        {
            var articles = await _dbContext.Articles.OrderByDescending(a => a.PublishedAt)
                .ToListAsync();

            if (articles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var articleDtos = _mappingHelper.MapListModelsToFirstType(articles);

            return articleDtos;
        }

        public async Task UpdateArticle(ArticleDto article)
        {
            if (article is null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            var articleToUpdate = await _dbContext.Articles.FirstOrDefaultAsync(a => a.Id == article.Id);

            if (articleToUpdate is null)
            {
                throw new ArticleNotFoundException(article.Id);
            }

            articleToUpdate = _mappingHelper.MapModelToSecondType(article);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ArticleDto> GetPublishedArticleById(int id)
        {
            var article = await _dbContext.Articles.Where(a => a.PublishedAt != null)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (article is null)
            {
                throw new ArticleNotFoundException(id);
            }

            var articleDto = _mappingHelper.MapModelToFirstType(article);

            return articleDto;
        }
    }
}
