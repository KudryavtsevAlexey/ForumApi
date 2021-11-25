using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record ListingDto(
        int Id,
        string Title,
        string ShortDescription,
        string Category,
        IEnumerable<TagDto> Tags,
        int OrganizationId,
        OrganizationDto Organization,
        int UserId,
        UserDto User,
        DateTime? PublishedAt,
        IEnumerable<ListingMainCommentDto> MainComments);
}
