using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<ArticleMainComment> GetComments()
        {
            return _dbContext.ArticleMainComments
                .Include(c=>c.SubComments)
                .ToList();
        }

        public async Task<ArticleMainComment> GetCommentById(int id)
        {
            return await _dbContext.ArticleMainComments.FindAsync(id);
        }
    }
}
