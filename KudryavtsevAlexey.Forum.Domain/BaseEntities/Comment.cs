using System;
using KudryavtsevAlexey.Forum.Domain.Entities;

namespace KudryavtsevAlexey.Forum.Domain.BaseEntities
{
    public class Comment : BaseEntity
    {
	    public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }
	}
}
