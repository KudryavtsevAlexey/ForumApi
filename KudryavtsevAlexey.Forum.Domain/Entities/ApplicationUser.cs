using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;
using Microsoft.AspNetCore.Identity;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
	public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }

		public string Summary { get; set; }

		public string Location { get; set; }

		public DateTime JoinedAt { get; set; }

		public ICollection<Article> Articles { get; set; }

		public ICollection<Subscriber> Subscribers { get; set; }

		public ICollection<Listing> Listings { get; set; }

        public int OrganizationId { get; set; }

		public Organization Organization { get; set; }

		public string ImageUrl { get; set; } = "ProfileImages\\ProfileImage.png";
	}
}
