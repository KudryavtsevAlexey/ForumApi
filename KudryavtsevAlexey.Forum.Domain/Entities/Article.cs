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
	    [Required]
		public string Title { get; set; }

		[Required]
		public string ShortDescription { get; set; }

		[Required]
		public ICollection<Tag> Tags { get; set; } = new List<Tag>();

		[Required]
        public int OrganizationId { get; set; }

	    [Required]
		public Organization Organization { get; set; }

		[Required]
        public int UserId { get; set; }

		[Required]
		public User User { get; set; }

		public DateTime? PublishedAt { get; set; }

        public ICollection<ArticleMainComment> MainComments { get; set; } = new List<ArticleMainComment>();
    }
}
