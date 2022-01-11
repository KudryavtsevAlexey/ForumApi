using System;
using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Article
{
    public record ArticleDto(
        int Id,
        string Title,
        string ShortDescription, 
        List<TagDto> Tags,
        int UserId,
        ApplicationUserDto User,
        DateTime? PublishedAt,
        List<ArticleMainCommentDto> MainComments) : BaseDto(Id);
}
