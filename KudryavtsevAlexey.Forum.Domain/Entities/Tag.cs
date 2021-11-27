using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<Listing> Listings { get; set; }
    }
}
