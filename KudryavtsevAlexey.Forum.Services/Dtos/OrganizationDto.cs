using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record OrganizationDto(
        int Id,
        string Name,
        IEnumerable<ListingDto> Listings,
        IEnumerable<UserDto> Users,
        IEnumerable<ArticleDto> Articles,
        string ImageUrl);
}
