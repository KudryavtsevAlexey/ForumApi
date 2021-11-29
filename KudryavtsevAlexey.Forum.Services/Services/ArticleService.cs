using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.EntityFrameworkCore;

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

            var articleToAdding = new Article();

            var tags = await _dbContext.Tags.ToListAsync();
            int[] identifiers = tags.Select(x => x.Id).ToArray();

            if (!(article.Tags is null))
            {
                articleToAdding.Tags = new List<Tag>();
                for (int i = 0; i < article.Tags.Count; i++)
                {
                    if (identifiers.Contains(article.Tags[i].Id))
                    {
                        int tagId = article.Tags[i].Id;
                        tags[tagId-1].Articles = new List<Article>() { articleToAdding };
                        articleToAdding.Tags.Add(tags[tagId-1]);
                    }
                }
            }

            var organization = await _dbContext.Organizations
                .FirstOrDefaultAsync(x => x.Id == article.OrganizationId);

            if (organization is null)
            {
                throw new OrganizationNotFoundException(article.Organization.Name);
            }

            organization.Articles = new List<Article>() { articleToAdding };

            articleToAdding.Organization = organization;

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == article.UserId);

            if (user is null)
            {
                throw new UserNotFoundException(article.UserId);
            }

            user.Articles = new List<Article>() { articleToAdding };

            articleToAdding.User = user;

            articleToAdding.Title = article.Title;
            articleToAdding.ShortDescription = article.ShortDescription;

            try
            {
                await _dbContext.Articles.AddAsync(articleToAdding);
                await _dbContext.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException) when (!ArticleExists(article.Id).GetAwaiter().GetResult())
            {
                // TODO: ILogger
            }
        }

        public async Task<ArticleDto> GetArticleById(int id)
        {
            var article = await _dbContext.Articles
                .Include(x => x.User)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (article is null)
            {
                throw new ArticleNotFoundException(id);
            }

            var articleDto = _mapper.Map<ArticleDto>(article);

            return articleDto;
        }

        public async Task<List<ArticleDto>> GetArticlesByUserId(int id)
        {
            var userArticles = await _dbContext.Articles
                .Where(x => x.UserId == id)
                .Include(x => x.Tags)
                .ToListAsync();

            if (userArticles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var userArticlesDtos = _mapper.Map<List<ArticleDto>>(userArticles);

            return userArticlesDtos;
        }

        public async Task<List<ArticleDto>> GetPublishedArticles()
        {
            var publishedArticles = await _dbContext.Articles
                .Where(x => x.PublishedAt != null)
                .Include(x => x.User)
                .Include(x => x.Tags)
                .ToListAsync();

            if (publishedArticles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var publishedArticlesDtos = _mapper.Map<List<ArticleDto>>(publishedArticles);

            return publishedArticlesDtos;
        }

        public async Task<List<ArticleDto>> GetPublishedArticlesByUserId(int id)
        {
            var userPublishedArticles = await _dbContext.Articles
                .Where(x => x.UserId == id)
                .Where(x => x.PublishedAt != null)
                .Include(x => x.User)
                .Include(x => x.Tags)
                .ToListAsync();

            if (userPublishedArticles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var userPublishedArticlesDtos = _mapper.Map<List<ArticleDto>>(userPublishedArticles);

            return userPublishedArticlesDtos;
        }

        public async Task<List<ArticleDto>> GetUnpublishedArticlesByUserId(int id)
        {
            var userUnpublishedArticles = await _dbContext.Articles
                .Where(x => x.UserId == id)
                .Where(x => x.PublishedAt == null)
                .Include(x => x.User)
                .Include(x => x.Tags)
                .ToListAsync();

            if (userUnpublishedArticles is null)
            {
                throw new ArticlesNotFoundException();
            }

            var userUnpublishedArticlesDtos = _mapper.Map<List<ArticleDto>>(userUnpublishedArticles);

            return userUnpublishedArticlesDtos;
        }

        public async Task<List<ArticleDto>> SortArticlesByDate()
        {
            var articlesByDate = await _dbContext.Articles
                .OrderByDescending(x => x.PublishedAt)
                .Include(x => x.User)
                .Include(x => x.Tags)
                .ToListAsync();

            if (articlesByDate is null)
            {
                throw new ArticlesNotFoundException();
            }

            var articlesByDateDtos = _mapper.Map<List<ArticleDto>>(articlesByDate);

            return articlesByDateDtos;
        }

        public async Task UpdateArticle(int id, PutArticleDto article)
        {
            if (article is null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            var articleToUpdating = await _dbContext.Articles
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (articleToUpdating is null)
            {
                throw new ArticleNotFoundException(id);
            }

            articleToUpdating.Title = article.Title;
            articleToUpdating.ShortDescription = article.ShortDescription;

            var tags = await _dbContext.Tags.ToListAsync();
            int[] identifiers = tags.Select(x => x.Id).ToArray();

            if (!(article.Tags is null))
            {
                articleToUpdating.Tags = new List<Tag>();
                for (int i = 0; i < article.Tags.Count; i++)
                {
                    if (identifiers.Contains(article.Tags[i].Id))
                    {
                        int tagId = article.Tags[i].Id;
                        tags[tagId-1].Articles = new List<Article>() { articleToUpdating };
                        articleToUpdating.Tags.Add(tags[tagId-1]);
                    }
                }
            }

            try
            {
                _dbContext.Articles.Update(articleToUpdating);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ArticleExists(articleToUpdating.Id).GetAwaiter().GetResult())
            {
                // TODO: ILogger
            }
        }

        public async Task<ArticleDto> GetPublishedArticleById(int id)
        {
            var publishedArticle = await _dbContext.Articles
                .Where(x => x.PublishedAt != null)
                .Include(x => x.User)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (publishedArticle is null)
            {
                throw new ArticleNotFoundException(id);
            }

            var publishedArticleDto = _mapper.Map<ArticleDto>(publishedArticle);

            return publishedArticleDto;
        }

        private async Task<bool> ArticleExists(int id)
        {
            return await _dbContext.Articles.AnyAsync(x => x.Id == id);
        }
    }
}