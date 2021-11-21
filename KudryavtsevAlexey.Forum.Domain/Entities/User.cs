using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
	public class User : BaseEntity
    {
	    [Required]
		public string UserName { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Summary { get; set; }

		[Required]
		public string Location { get; set; }

		[Required]
		public DateTime JoinedAt { get; set; }

		public ICollection<Article> Articles { get; set; } = new List<Article>();

		public ICollection<Subscriber> Subscribers { get; set; } = new List<Subscriber>();

		public ICollection<Listing> Listings { get; set; } = new List<Listing>();

        public int OrganizationId { get; set; }

		public Organization Organization { get; set; }

		public string ImageUrl { get; set; } = "ProfileImages\\ProfileImage.png";
	}
}
