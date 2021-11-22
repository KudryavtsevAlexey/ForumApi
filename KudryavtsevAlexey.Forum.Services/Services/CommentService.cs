using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.EntityFrameworkCore;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    internal sealed class CommentService : ICommentService
    {
        private readonly ForumDbContext _dbContext;

        public CommentService(ForumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ArticleMainComment>> GetArticleComments(Article article)
        {
            return await _dbContext.ArticleMainComments
                .Include(c => c.SubComments)
                .Where(a => a.Article == article)
                .ToListAsync();
        }

        public async Task<List<ListingMainComment>> GetListingComments(Listing listing)
        {
            return await _dbContext.ListingMainComments
                .Include(c => c.SubComments)
                .Where(a => a.Listing == listing)
                .ToListAsync();
        }

        public async Task<ArticleMainComment> GetArticleMainCommentById(int id)
        {
            return await _dbContext.ArticleMainComments
                .Include(c => c.SubComments)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ListingMainComment> GetListingMainCommentById(int id)
        {
            return await _dbContext.ListingMainComments
                .Include(c => c.SubComments)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ArticleSubComment> GetArticleSubCommentById(int id)
        {
            return await _dbContext.ArticleSubComments
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ListingSubComment> GetListingSubCommentById(int id)
        {
            return await _dbContext.ListingSubComments
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<ArticleMainComment>> GetAllArticleComments()
        {
            return await _dbContext.ArticleMainComments
                .Include(c => c.SubComments)
                .ToListAsync();
        }

        public async Task<List<ListingMainComment>> GetAllListingComments()
        {
            return await _dbContext.ListingMainComments
                .Include(c => c.SubComments)
                .ToListAsync();
        }
    }
}
