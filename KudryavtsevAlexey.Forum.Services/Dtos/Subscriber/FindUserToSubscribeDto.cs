using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Subscriber
{
	public record FindUserToSubscribeDto(
		int UserId,
		int SubscriberId);
}
