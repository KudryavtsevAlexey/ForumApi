using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        public Organization()
        {
	        Users = new List<ApplicationUser>();
        }
    }
}