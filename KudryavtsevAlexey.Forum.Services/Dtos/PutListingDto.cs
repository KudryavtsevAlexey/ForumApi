using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record PutListingDto(
        string Title,
        string ShortDescription,
        string Category,
        List<TagDto> Tags);
}
