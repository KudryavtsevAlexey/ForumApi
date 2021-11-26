using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.CustomExceptions;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    internal sealed class CommentService : ICommentService
    {
        private readonly ForumDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentService(ForumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ArticleMainCommentDto>> GetArticleComments(ArticleDto article)
        {
            var articleMainComments = await _dbContext.ArticleMainComments
                .Include(c => c.SubComments)
                .Where(a => a.ArticleId == article.Id)
                .Include(a=>a.Article)
                .ToListAsync();

            if (articleMainComments is null)
            {
                throw new ArticleMainCommentsNotFoundException(article.Id);
            }

            var articleMainCommentsDtos = _mapper.Map<List<ArticleMainComment>, List<ArticleMainCommentDto>>(articleMainComments);

            return articleMainCommentsDtos;
        }

        public async Task<List<ListingMainCommentDto>> GetListingComments(ListingDto listing)
        {
            var listingMainComments = await _dbContext.ListingMainComments
                .Include(c => c.SubComments)
                .Where(a => a.ListingId == listing.Id)
                .Include(l => l.Listing)
                .ToListAsync();

            if (listingMainComments is null)
            {
                throw new ListingMainCommentsNotFoundException(listing.Id);
            }

            var listingMainCommentsDtos = _mapper.Map<List<ListingMainComment>, List<ListingMainCommentDto>>(listingMainComments);

            return listingMainCommentsDtos;
        }

        public async Task<ArticleMainCommentDto> GetArticleMainCommentById(int id)
        {
            var articleMainComment = await _dbContext.ArticleMainComments
                .Include(c => c.SubComments)
                .Include(a => a.Article)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (articleMainComment is null)
            {
                throw new ArticleMainCommentNotFoundException(id);
            }

            var articleMainCommentDto = _mapper.Map<ArticleMainComment, ArticleMainCommentDto>(articleMainComment);

            return articleMainCommentDto;
        }

        public async Task<ListingMainCommentDto> GetListingMainCommentById(int id)
        {
            var listingMainComment = await _dbContext.ListingMainComments
                .Include(c => c.SubComments)
                .Include(l => l.Listing)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (listingMainComment is null)
            {
                throw new ListingMainCommentNotFoundException(id);
            }

            var listingMainCommentDto = _mapper.Map<ListingMainComment, ListingMainCommentDto>(listingMainComment);

            return listingMainCommentDto;
        }

        public async Task<ArticleSubCommentDto> GetArticleSubCommentById(int id)
        {
            var articleSubComment = await _dbContext.ArticleSubComments
                .Include(c=>c.ArticleMainComment)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (articleSubComment is null)
            {
                throw new ArticleSubCommentNotFoundException(id);
            }

            var articleSubCommentDto = _mapper.Map<ArticleSubComment, ArticleSubCommentDto>(articleSubComment);

            return articleSubCommentDto;
        }

        public async Task<ListingSubCommentDto> GetListingSubCommentById(int id)
        {
            var listingSubComment = await _dbContext.ListingSubComments
                .Include(c=>c.ListingMainComment)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (listingSubComment is null)
            {
                throw new ListingSubCommentNotFoundException(id);
            }

            var listingSubCommentDto = _mapper.Map<ListingSubComment, ListingSubCommentDto>(listingSubComment);

            return listingSubCommentDto;
        }

        public async Task<List<ArticleMainCommentDto>> GetAllArticlesComments()
        {
            var allArticleMainComments = await _dbContext.ArticleMainComments
                .Include(c => c.SubComments)
                .Include(x=>x.Article)
                .ToListAsync();

            if (allArticleMainComments is null)
            {
                throw new ArticlesCommentsNotFoundException();
            }

            var allArticlesMainCommentsDtos = _mapper.Map<List<ArticleMainComment>, List<ArticleMainCommentDto>>(allArticleMainComments);

            return allArticlesMainCommentsDtos;
        }

        public async Task<List<ListingMainCommentDto>> GetAllListingsComments()
        {
            var allListingMainComments = await _dbContext.ListingMainComments
                .Include(c => c.SubComments)
                .Include(x=>x.Listing)
                .ToListAsync();

            if (allListingMainComments is null)
            {
                throw new ListingsCommentsNotFoundException();
            }

            var allListingsMainCommentsDtos = _mapper.Map<List<ListingMainComment>, List<ListingMainCommentDto>>(allListingMainComments);

            return allListingsMainCommentsDtos;
        }
    }
}
