using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.MappingHelpers;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                .Where(a => a.Article == article)
                .Include(a=>a.Article)
                .ToListAsync();

            var articleMainCommentsDtos = MappingHelper.MapListModelsToFirstType<ArticleMainCommentDto, ArticleMainComment>(articleMainComments, _mapper);

            return articleMainCommentsDtos;
        }

        public async Task<List<ListingMainCommentDto>> GetListingComments(ListingDto listing)
        {
            var listingMainComments = await _dbContext.ListingMainComments
                .Include(c => c.SubComments)
                .Where(a => a.Listing == listing)
                .Include(l => l.Listing)
                .ToListAsync();

            var listingMainCommentsDtos = MappingHelper.MapListModelsToFirstType<ListingMainCommentDto, ListingMainComment>(listingMainComments, _mapper);

            return listingMainCommentsDtos;
        }

        public async Task<ArticleMainCommentDto> GetArticleMainCommentById(int id)
        {
            var articleMainComment = await _dbContext.ArticleMainComments
                .Include(c => c.SubComments)
                .Include(a => a.Article)
                .FirstOrDefaultAsync(c => c.Id == id);

            var articleMainCommentDto = MappingHelper.MapModelToFirstType<ArticleMainCommentDto, ArticleMainComment>(articleMainComment, _mapper);

            return articleMainCommentDto;
        }

        public async Task<ListingMainCommentDto> GetListingMainCommentById(int id)
        {
            var listingMainComment = await _dbContext.ListingMainComments
                .Include(c => c.SubComments)
                .Include(l => l.Listing)
                .FirstOrDefaultAsync(c => c.Id == id);

            var listingMainCommentDto = MappingHelper.MapModelToFirstType<ListingMainCommentDto, ListingMainComment>(listingMainComment, _mapper);

            return listingMainCommentDto;
        }

        public async Task<ArticleSubCommentDto> GetArticleSubCommentById(int id)
        {
            var articleSubComment = await _dbContext.ArticleSubComments
                .Include(c=>c.ArticleMainComment)
                .FirstOrDefaultAsync(c => c.Id == id);

            var articleSubCommentDto = MappingHelper.MapModelToFirstType<ArticleSubCommentDto, ArticleSubComment>(articleSubComment, _mapper);

            return articleSubCommentDto;
        }

        public async Task<ListingSubCommentDto> GetListingSubCommentById(int id)
        {
            var listingSubComment = await _dbContext.ListingSubComments
                .Include(c=>c.ListingMainComment)
                .FirstOrDefaultAsync(c => c.Id == id);

            var listingSubCommentDto = MappingHelper.MapModelToFirstType<ListingSubCommentDto, ListingSubComment>(listingSubComment, _mapper);

            return listingSubCommentDto;
        }

        public async Task<List<ArticleMainCommentDto>> GetAllArticleComments()
        {
            var allArticleMainComments = await _dbContext.ArticleMainComments
                .Include(c => c.SubComments)
                .Include(x=>x.Article)
                .ToListAsync();

            var allArticlesMainCommentsDtos = MappingHelper.MapListModelsToFirstType<ArticleMainCommentDto, ArticleMainComment>(allArticleMainComments, _mapper);

            return allArticlesMainCommentsDtos;
        }

        public async Task<List<ListingMainCommentDto>> GetAllListingComments()
        {
            var allListingMainComments = await _dbContext.ListingMainComments
                .Include(c => c.SubComments)
                .Include(x=>x.Listing)
                .ToListAsync();

            var allListingsMainCommentsDtos = MappingHelper.MapListModelsToFirstType<ListingMainCommentDto, ListingMainComment>(allListingMainComments, _mapper);

            return allListingsMainCommentsDtos;
        }
    }
}
