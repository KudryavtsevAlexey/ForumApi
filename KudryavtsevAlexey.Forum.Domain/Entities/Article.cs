using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
	public class Article : BaseEntity
    {
        public string Title { get; set; }

		public string ShortDescription { get; set; }

		public ICollection<Tag> Tags { get; set; }

        public int OrganizationId { get; set; }

		public Organization Organization { get; set; }

        public int UserId { get; set; }

		public User User { get; set; }

		public DateTime? PublishedAt { get; set; }

        public ICollection<ArticleMainComment> MainComments { get; set; }
    }
}
