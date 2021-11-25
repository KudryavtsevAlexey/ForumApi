using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record TagDto(
        int Id,
        string Name,
        IEnumerable<ArticleDto> Articles,
        IEnumerable<ListingDto> Listings);
}
