using KudryavtsevAlexey.Forum.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface ITagService
    {
        public Task<List<Tag>> GetTags();
    }
}
