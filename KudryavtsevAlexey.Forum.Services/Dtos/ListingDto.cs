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
        List<TagDto> Tags,
        int OrganizationId,
        OrganizationDto Organization,
        int UserId,
        ApplicationUserDto User,
        DateTime? PublishedAt,
        List<ListingMainCommentDto> MainComments) : BaseDto(Id);
}
