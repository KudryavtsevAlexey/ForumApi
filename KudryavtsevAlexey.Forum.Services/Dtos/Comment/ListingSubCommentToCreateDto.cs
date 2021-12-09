using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record ListingSubCommentToCreateDto(
        string Content,
        int UserId,
        int ListingMainCommentId,
        int ListingId,
        DateTime? CreatedAt) : BaseCommentDto(Content, UserId, CreatedAt);
}
