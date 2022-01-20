using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record UpdateListingSubCommentDto(
        int Id,
        string Content) : BaseDto(Id);
}
