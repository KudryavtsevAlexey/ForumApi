using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Listing
{
    public record CreateListingDto(
        string Title,
        string ShortDescription,
        string Category,
        List<TagDto> Tags,
        int UserId);
}
