using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Subscriber
{
	public record SubscriptionDto(
		int Id,
		int UserId,
		ApplicationUser User) : BaseDto(Id);
}
