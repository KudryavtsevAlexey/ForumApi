using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record UpdateArticleMainCommentDto(
        int Id,
        string Content) : BaseDto(Id);
}
