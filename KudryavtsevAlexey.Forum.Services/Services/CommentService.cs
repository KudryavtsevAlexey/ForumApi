using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
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

        public async Task<List<ArticleMainCommentDto>> GetArticleComments(int id)
        {
            var articleMainComments = await _dbContext.ArticleMainComments
                .Where(x => x.ArticleId == id)
                .Include(x => x.Article)
                .Include(x => x.SubComments)
                .ToListAsync();

            List<ArticleMainCommentDto> articleMainCommentsDtos = _mapper.Map<List<ArticleMainCommentDto>>(articleMainComments);

            return articleMainCommentsDtos;
        }

        public async Task<List<ListingMainCommentDto>> GetListingComments(int id)
        {
            var listingMainComments = await _dbContext.ListingMainComments
                .Where(x => x.ListingId == id)
                .Include(x => x.Listing)
                .Include(x => x.SubComments)
                .ToListAsync();

            List<ListingMainCommentDto> listingMainCommentsDtos = _mapper.Map<List<ListingMainCommentDto>>(listingMainComments);

            return listingMainCommentsDtos;
        }

        public async Task<ArticleMainCommentDto> GetArticleMainCommentById(int id)
        {
            var articleMainComment = await _dbContext.ArticleMainComments
                .Include(x => x.Article)
                .Include(x => x.SubComments)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (articleMainComment is null)
            {
                throw new ArticleMainCommentNotFoundException(id);
            }

            var articleMainCommentDto = _mapper.Map<ArticleMainCommentDto>(articleMainComment);

            return articleMainCommentDto;
        }

        public async Task<ListingMainCommentDto> GetListingMainCommentById(int id)
        {
            var listingMainComment = await _dbContext.ListingMainComments
                .Include(x => x.Listing)
                .Include(x => x.SubComments)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (listingMainComment is null)
            {
                throw new ListingMainCommentNotFoundException(id);
            }

            var listingMainCommentDto = _mapper.Map<ListingMainCommentDto>(listingMainComment);

            return listingMainCommentDto;
        }

        public async Task<ArticleSubCommentDto> GetArticleSubCommentById(int id)
        {
            var articleSubComment = await _dbContext.ArticleSubComments
                .Include(x => x.Article)
                .Include(x => x.ArticleMainComment)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (articleSubComment is null)
            {
                throw new ArticleSubCommentNotFoundException(id);
            }

            var articleSubCommentDto = _mapper.Map<ArticleSubCommentDto>(articleSubComment);

            return articleSubCommentDto;
        }

        public async Task<ListingSubCommentDto> GetListingSubCommentById(int id)
        {
            var listingSubComment = await _dbContext.ListingSubComments
                .Include(x => x.Listing)
                .Include(x => x.ListingMainComment)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (listingSubComment is null)
            {
                throw new ListingSubCommentNotFoundException(id);
            }

            var listingSubCommentDto = _mapper.Map<ListingSubCommentDto>(listingSubComment);

            return listingSubCommentDto;
        }

        public async Task<List<ArticleMainCommentDto>> GetAllArticlesComments()
        {
            var allArticleMainComments = await _dbContext.ArticleMainComments
                .Include(x => x.Article)
                .Include(x => x.SubComments)
                .ToListAsync();

            var allArticlesMainCommentsDtos = _mapper.Map<List<ArticleMainCommentDto>>(allArticleMainComments);

            return allArticlesMainCommentsDtos;
        }

        public async Task<List<ListingMainCommentDto>> GetAllListingsComments()
        {
            var allListingMainComments = await _dbContext.ListingMainComments
                .Include(x => x.Listing)
                .Include(x => x.SubComments)
                .ToListAsync();

            var allListingsMainCommentsDtos = _mapper.Map<List<ListingMainCommentDto>>(allListingMainComments);

            return allListingsMainCommentsDtos;
        }

        public async Task CreateArticleMainComment(ArticleMainCommentDto articleMainCommentDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == articleMainCommentDto.UserId);

            if (user is null)
            {
                throw new UserNotFoundException(articleMainCommentDto.UserId);
            }

            var articleMainComment = _mapper.Map<ArticleMainComment>(articleMainCommentDto);

            await _dbContext.AddAsync(articleMainComment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
