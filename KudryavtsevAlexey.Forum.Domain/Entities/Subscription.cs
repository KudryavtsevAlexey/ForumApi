using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
	public class Subscription
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public ApplicationUser User { get; set; }
	}
}
