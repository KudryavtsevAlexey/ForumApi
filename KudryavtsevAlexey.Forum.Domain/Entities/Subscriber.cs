using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
    public class Subscriber : BaseEntity
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        public string ImageUrl { get; set; } = "ProfileImages\\ProfileImage.png";
    }
}
