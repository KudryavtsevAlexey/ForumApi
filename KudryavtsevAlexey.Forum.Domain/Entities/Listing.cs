using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
	public class Listing : BaseEntity
    {
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Category { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime? PublishedAt { get; set; }

        public ICollection<ListingMainComment> MainComments { get; set; }

        public Listing()
        {
            Tags = new List<Tag>();
            MainComments = new List<ListingMainComment>();
        }
    }
}
