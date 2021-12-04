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
        List<ListingDto> Listings,
        List<ApplicationUserDto> Users,
        List<ArticleDto> Articles,
        string ImageUrl) : BaseDto(Id);
}
