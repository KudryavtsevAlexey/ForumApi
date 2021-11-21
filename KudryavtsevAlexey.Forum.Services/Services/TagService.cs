using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    internal sealed class TagService : ITagService
    {
        private readonly ForumDbContext _dbContext;

        public TagService(ForumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Tag>> GetTags()
        {
            return await _dbContext.Tags.ToListAsync();
        }
    }
}
