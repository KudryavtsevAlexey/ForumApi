using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Dtos.User;
using System;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
	public record ListingSubCommentDto(
		int Id,
		string Content,
		DateTime? CreatedAt,
		int UserId,
		ApplicationUserDto User,
		int ListingId,
		ListingDto Listing,
		int ListingMainCommentId,
		ListingMainCommentDto ListingMainComment) : BaseCommentDto(Content, UserId, CreatedAt);
}
