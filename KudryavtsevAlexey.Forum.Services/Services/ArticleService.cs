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
using KudryavtsevAlexey.Forum.Services.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    internal sealed class ArticleService : IArticleService
    {
        private readonly IMapper _mapper;
        private readonly ForumDbContext _dbContext;

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

            var articleToAdding = MappingHelper.MapModelToSecondType<ArticleDto, Article>(article, _mapper);

            var organization = await _dbContext.Organizations.FirstOrDefaultAsync(o => o.Id == article.OrganizationId);

            if (organization is null)
            {
                throw new OrganizationNotFoundException(article.Organization.Name);
            }

            organization.Articles.Add(articleToAdding);

            articleToAdding.Organization = organization;

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == articleToAdding.UserId);

            if (user is null)
            {
                throw new UserNotFoundException(articleToAdding.UserId);
            }


            user.Articles.Add(articleToAdding);

            articleToAdding.User = user;

            try
            {
                await _dbContext.Articles.AddAsync(articleToAdding);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ArticleExists(articleToAdding.Id).GetAwaiter().GetResult())
            {
                // TODO: ILogger
            }
        }

        public async Task<Article> GetArticleById(int id)
        {
            var article = await _dbContext.Articles
                .Include(u=>u.User)
                .Include(o=>o.Organization)
                .Include(t=>t.Tags)
                .Include(c => c.MainComments)
                .ThenInclude(s => s.SubComments)
                .FirstOrDefaultAsync(a=>a.Id == id);

            if (article is null)
            {
                throw new ArticleNotFoundException(id);
            }

            return article;
        }

        public async Task<List<ArticleDto>> GetArticlesByUser(User user)
        {
            var articles = await _dbContext.Articles
                .Include(u=>u.User)
                .Where(a => a.User == user)
                .Include(o => o.Organization)
                .Include(t=>t.Tags)
                .Include(c => c.MainComments)
                .ThenInclude(s => s.SubComments)
                .ToListAsync();

            if (articles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var articleDtos = MappingHelper.MapListModelsToFirstType<ArticleDto, Article>(articles, _mapper);

            return articleDtos;
        }

        public async Task<List<ArticleDto>> GetPublishedArticles()
        {
            var articles = await _dbContext.Articles
                .Where(a => a.PublishedAt != null)
                .Include(u => u.User)
                .Include(o => o.Organization)
                .Include(t=>t.Tags)
                .Include(c => c.MainComments)
                .ThenInclude(s => s.SubComments)
                .ToListAsync();

            if (articles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var articleDtos = MappingHelper.MapListModelsToFirstType<ArticleDto, Article>(articles, _mapper);

            return articleDtos;
        }

        public async Task<List<ArticleDto>> GetPublishedArticlesByUser(User user)
        {
            var articles = await _dbContext.Articles
                .Where(a => a.User == user)
                .Where(a => a.PublishedAt != null)
                .Include(u => u.User)
                .Include(o => o.Organization)
                .Include(t=>t.Tags)
                .Include(c=>c.MainComments)
                .ThenInclude(s=>s.SubComments)
                .ToListAsync();

            if (articles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var articleDtos = MappingHelper.MapListModelsToFirstType<ArticleDto, Article>(articles, _mapper);

            return articleDtos;
        }

        public async Task<List<ArticleDto>> GetUnpublishedArticlesByUser(User user)
        {
            var articles = await _dbContext.Articles
                .Include(u=>u.User)
                .Where(a => a.User == user)
                .Where(a => a.PublishedAt == null)
                .Include(o => o.Organization)
                .Include(t => t.Tags)
                .Include(c => c.MainComments)
                .ThenInclude(s => s.SubComments)
                .ToListAsync();

            if (articles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var articleDtos = MappingHelper.MapListModelsToFirstType<ArticleDto, Article>(articles, _mapper);

            return articleDtos;
        }

        public async Task<List<ArticleDto>> SortArticlesByDate()
        {
            var articles = await _dbContext.Articles
                .OrderByDescending(a => a.PublishedAt)
                .Include(u=>u.User)
                .Include(o=>o.Organization)
                .Include(t => t.Tags)
                .Include(c => c.MainComments)
                .ThenInclude(s => s.SubComments)
                .ToListAsync();

            if (articles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var articleDtos = MappingHelper.MapListModelsToFirstType<ArticleDto, Article>(articles, _mapper);

            return articleDtos;
        }

        public async Task UpdateArticle(int id, PutArticleDto article)
        {
            if (article is null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            var articleToUpdate = await _dbContext.Articles
                .Include(x=>x.Tags)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (articleToUpdate is null)
            {
                throw new ArticleNotFoundException(id);
            }

            articleToUpdate.Tags = article.Tags;
            articleToUpdate.Title = article.Title;
            articleToUpdate.ShortDescription = article.ShortDescription;

            try
            {
                _dbContext.Update(articleToUpdate);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ArticleExists(articleToUpdate.Id).GetAwaiter().GetResult())
            {
                // TODO: ILogger
            }
        }

        public async Task<ArticleDto> GetPublishedArticleById(int id)
        {
            var article = await _dbContext.Articles
                .Where(a => a.PublishedAt != null)
                .Include(u=>u.User)
                .Include(o=>o.Organization)
                .Include(t => t.Tags)
                .Include(c => c.MainComments)
                .ThenInclude(s => s.SubComments)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (article is null)
            {
                throw new ArticleNotFoundException(id);
            }

            var articleDto = MappingHelper.MapModelToFirstType<ArticleDto, Article>(article, _mapper);

            return articleDto;
        }

        private async Task<bool> ArticleExists(int id)
        {
            return await _dbContext.Articles.AnyAsync(a => a.Id == id);
        }
    }
}
