using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
	public class Organization : BaseEntity
	{
		[Required]
        public string Name { get; set; }

        public ICollection<Listing> Listings { get; set; } = new List<Listing>();

        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<Article> Articles { get; set; } = new List<Article>();

        public string ImageUrl { get; set; } = "C:\\Users\\Lenovo\\source\\repos\\KudryavtsevAlexey.Forum\\KudryavtsevAlexey.Forum.Domain\\ProfileImages\\ProfileImage.png";
    }
}
