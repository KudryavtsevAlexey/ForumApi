using System;

namespace KudryavtsevAlexey.Forum.Domain.BaseEntities
{
    public class Comment : BaseEntity
    {
	    public string Name { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}
