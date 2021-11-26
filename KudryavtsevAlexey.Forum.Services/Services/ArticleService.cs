using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

            var articleToAdding = _mapper.Map<ArticleDto, Article>(article);

            var tags = new List<Tag>();

            if (!(article.Tags is null))
            {
                foreach (var articleTag in article.Tags)
                {
                    var tag = await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == articleTag.Id);

                    if (tag is null) throw new TagNotFoundException(articleTag.Id);

                    tags.Add(tag);
                }
            }

            articleToAdding.Tags = new List<Tag>(tags);

            var organization = await _dbContext.Organizations.FirstOrDefaultAsync(o => o.Id == article.OrganizationId);

            if (organization is null)
            {
                throw new OrganizationNotFoundException(article.Organization.Name);
            }

            organization.Articles = new List<Article>();
            organization.Articles.Add(articleToAdding);

            articleToAdding.Organization = organization;

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == articleToAdding.UserId);

            if (user is null) throw new UserNotFoundException(articleToAdding.UserId);

            user.Articles = new List<Article>();
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

        public async Task<ArticleDto> GetArticleById(int id)
        {
            var article = await _dbContext.Articles
                .Include(x=>x.User)
                .Include(x=>x.Tags)
                .FirstOrDefaultAsync(a => a.Id == id);

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
                .Include(u => u.User)
                .Where(a => a.UserId == id)
                .Include(o => o.Organization)
                .Include(t => t.Tags)
                .Include(c => c.MainComments)
                .ThenInclude(s => s.SubComments)
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
                .Where(a => a.PublishedAt != null)
                .Include(u => u.User)
                .Include(o => o.Organization)
                .Include(t => t.Tags)
                .Include(c => c.MainComments)
                .ThenInclude(s => s.SubComments)
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
                .Where(a => a.UserId == id)
                .Where(a => a.PublishedAt != null)
                .Include(u => u.User)
                .Include(o => o.Organization)
                .Include(t => t.Tags)
                .Include(c => c.MainComments)
                .ThenInclude(s => s.SubComments)
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
                .Include(u => u.User)
                .Where(a => a.UserId == id)
                .Where(a => a.PublishedAt == null)
                .Include(o => o.Organization)
                .Include(t => t.Tags)
                .Include(c => c.MainComments)
                .ThenInclude(s => s.SubComments)
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
                .OrderByDescending(a => a.PublishedAt)
                .Include(u => u.User)
                .Include(o => o.Organization)
                .Include(t => t.Tags)
                .Include(c => c.MainComments)
                .ThenInclude(s => s.SubComments)
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

            var articleToUpdate = await _dbContext.Articles
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (articleToUpdate is null)
            {
                throw new ArticleNotFoundException(id);
            }

            var tags = new List<Tag>();

            if (!(article.Tags is null))
            {
                foreach (var articleTag in article.Tags)
                {
                    var tag = await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == articleTag.Id);

                    if (tag is null) throw new TagNotFoundException(articleTag.Id);

                    tags.Add(tag);
                }
            }

            articleToUpdate.Tags = new List<Tag>(tags);
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
            var publishedArticle = await _dbContext.Articles
                .Where(a => a.PublishedAt != null)
                .Include(u => u.User)
                .Include(o => o.Organization)
                .Include(t => t.Tags)
                .Include(c => c.MainComments)
                .ThenInclude(s => s.SubComments)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (publishedArticle is null)
            {
                throw new ArticleNotFoundException(id);
            }

            var publishedArticleDto = _mapper.Map<ArticleDto>(publishedArticle);

            return publishedArticleDto;
        }

        private async Task<bool> ArticleExists(int id)
        {
            return await _dbContext.Articles.AnyAsync(a => a.Id == id);
        }
    }
}