using System;
using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }

		public string ShortDescription { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public int UserId { get; set; }

		public ApplicationUser User { get; set; }

		public DateTime? PublishedAt { get; set; }

        public ICollection<ArticleMainComment> MainComments { get; set; }

        public Article()
        {
            Tags = new List<Tag>();
            MainComments = new List<ArticleMainComment>();
        }
    }
}
