using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Subscriber
{
	public record SubscriberDto(
		int Id,
		int UserId,
		ApplicationUser User) : BaseDto(Id);
}
