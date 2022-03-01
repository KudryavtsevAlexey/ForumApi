using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record UpdateListingSubCommentDto(
        int Id,
        string Content) : BaseDto(Id);
}
