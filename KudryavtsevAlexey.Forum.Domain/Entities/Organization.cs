﻿using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Listing> Listings { get; set; } = new List<Listing>();

        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<Article> Articles { get; set; } = new List<Article>();

        public string ImageUrl { get; set; } = "ProfileImages\\ProfileImage.png";
    }
}