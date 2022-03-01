using System;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Base
{
    public record BaseCommentDto(string Content, int UserId, DateTime? CreatedAt = null)
    {
        public DateTime? CreatedAt { get; init; } = CreatedAt ?? DateTime.UtcNow.Date;
    }
}
