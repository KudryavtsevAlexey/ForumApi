using KudryavtsevAlexey.Forum.Services.Dtos.User;
using System;
using System.Data;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Base
{
    public record BaseCommentDto(string Content, int UserId, DateTime? CreatedAt = null)
    {
        public DateTime? CreatedAt { get; init; } = CreatedAt ?? DateTime.UtcNow.Date;
    }
}
