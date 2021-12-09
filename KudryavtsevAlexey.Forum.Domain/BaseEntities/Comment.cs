using KudryavtsevAlexey.Forum.Domain.Entities;
using System;

namespace KudryavtsevAlexey.Forum.Domain.BaseEntities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }
	}
}
