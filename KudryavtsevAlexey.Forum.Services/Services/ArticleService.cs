using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            var userUnpublishedArticlesDtos = _mapper.Map<List<ArticleDto>>(userUnpublishedArticles);

            return userUnpublishedArticlesDtos;
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

        public async Task<List<ArticleDto>> SortArticlesByDate()
        {
            var articlesByDate = await _dbContext.Articles
                .OrderByDescending(x => x.PublishedAt)
                .Include(x => x.User)
                .Include(x => x.Tags)
                .ToListAsync();

            var articlesByDateDtos = _mapper.Map<List<ArticleDto>>(articlesByDate);

            return articlesByDateDtos;
        }

        public async Task CreateArticle(ArticleToCreateDto articleDto)
        {
            if (articleDto is null)
            {
                throw new ArgumentNullException(nameof(articleDto));
            }

            var articleToAdding = new Article();

            var tags = await _dbContext.Tags.ToListAsync();
            int[] identifiers = tags.Select(x => x.Id).ToArray();

            if (!(articleDto.Tags is null))
            {
                articleToAdding.Tags = new List<Tag>();
                for (int i = 0; i < articleDto.Tags.Count; i++)
                {
                    if (identifiers.Contains(articleDto.Tags[i].Id))
                    {
                        int tagId = articleDto.Tags[i].Id;
                        tags[tagId - 1].Articles = new List<Article>() { articleToAdding };
                        articleToAdding.Tags.Add(tags[tagId - 1]);
                    }
                }
            }

            var organization = await _dbContext.Organizations
                .FirstOrDefaultAsync(x => x.Id == articleDto.OrganizationId);

            if (organization is null)
            {
                throw new OrganizationNotFoundException(articleDto.OrganizationId);
            }

            organization.Articles = new List<Article>() { articleToAdding };

            articleToAdding.Organization = organization;

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == articleDto.UserId);

            if (user is null)
            {
                throw new UserNotFoundException(articleDto.UserId);
            }

            user.Articles = new List<Article>() { articleToAdding };

            articleToAdding.User = user;

            articleToAdding.Title = articleDto.Title;
            articleToAdding.ShortDescription = articleDto.ShortDescription;

            await _dbContext.Articles.AddAsync(articleToAdding);
            await _dbContext.SaveChangesAsync();
        }
   
        public async Task UpdateArticle(int id, ArticleToUpdateDto articleDto)
        {
            if (articleDto is null)
            {
                throw new ArgumentNullException(nameof(articleDto));
            }

            var articleToUpdating = await _dbContext.Articles
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (articleToUpdating is null)
            {
                throw new ArticleNotFoundException(id);
            }

            articleToUpdating.Title = articleDto.Title;
            articleToUpdating.ShortDescription = articleDto.ShortDescription;

            var tags = await _dbContext.Tags.ToListAsync();
            int[] identifiers = tags.Select(x => x.Id).ToArray();

            if (!(articleDto.Tags is null))
            {
                articleToUpdating.Tags = new List<Tag>();
                for (int i = 0; i < articleDto.Tags.Count; i++)
                {
                    if (identifiers.Contains(articleDto.Tags[i].Id))
                    {
                        int tagId = articleDto.Tags[i].Id;
                        tags[tagId - 1].Articles = new List<Article>() { articleToUpdating };
                        articleToUpdating.Tags.Add(tags[tagId - 1]);
                    }
                }
            }

            _dbContext.Articles.Update(articleToUpdating);
            await _dbContext.SaveChangesAsync();
        }
    }
}