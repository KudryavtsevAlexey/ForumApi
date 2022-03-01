namespace KudryavtsevAlexey.Forum.Domain.Entities
{
	public class Subscription
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public ApplicationUser User { get; set; }
	}
}
