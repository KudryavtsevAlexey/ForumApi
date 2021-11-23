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
using KudryavtsevAlexey.Forum.Services.Dto;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    internal sealed class ArticleService : IArticleService
    {
        private readonly ForumDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArticleService(ForumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddArticle(ArticleDto article)
        {
            if (article is null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            var articleToAdding = _mapper.Map<Article>(article);

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

        public async Task<List<Article>> GetArticlesByUser(User user)
        {
            return await _dbContext.Articles.Where(a => a.User == user)
                .ToListAsync();
        }

        public async Task<List<Article>> GetPublishedArticles()
        {
            return await _dbContext.Articles.Where(a => a.PublishedAt != null)
                .ToListAsync();
        }

        public async Task<List<Article>> GetPublishedArticlesByUser(User user)
        {
            return await _dbContext.Articles.Where(a => a.User == user)
                .Where(a=>a.PublishedAt!=null)
                .ToListAsync();
        }

        public async Task<List<Article>> GetUnpublishedArticlesByUser(User user)
        {
            return await _dbContext.Articles.Where(a => a.User == user)
                .Where(a => a.PublishedAt == null)
                .ToListAsync();
        }

        public async Task<List<Article>> SortArticlesByDate()
        {
            return await _dbContext.Articles.OrderByDescending(a => a.PublishedAt)
                .ToListAsync();
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

            var updatedArticle = _mapper.Map<Article>(article);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Article> GetPublishedArticleById(int id)
        {
            return await _dbContext.Articles.Where(a => a.PublishedAt != null)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
