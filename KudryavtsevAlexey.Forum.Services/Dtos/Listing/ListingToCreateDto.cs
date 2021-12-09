using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Listing
{
    public record ListingToCreateDto(
        string Title,
        string ShortDescription,
        string Category,
        List<TagDto> Tags,
        int UserId,
        int OrganizationId);
}
