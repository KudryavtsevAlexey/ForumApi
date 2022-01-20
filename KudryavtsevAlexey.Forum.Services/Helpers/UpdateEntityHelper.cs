using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace KudryavtsevAlexey.Forum.Services.Helpers
{
	public static class UpdateEntityHelper
	{
		public static void DetachEntity<T>(this ForumDbContext dbContext, T entity, int id) where T : class, IIdentifier
		{
			var local = dbContext.Set<T>()
				.Local.FirstOrDefault(x => x.Id.Equals(id));

			if (!(local is null))
			{
				dbContext.Entry(local).State = EntityState.Detached;
			}

			dbContext.Entry(entity).State = EntityState.Modified;
		}
	}
}
