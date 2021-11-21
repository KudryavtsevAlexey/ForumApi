using System;

using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities.Comments
{
    public class Comment : BaseEntity
    {
	    public string Name { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}
