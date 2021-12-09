using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Listing
{
    public record PutListingDto(
        string Title,
        string ShortDescription,
        string Category,
        List<TagDto> Tags);
}
