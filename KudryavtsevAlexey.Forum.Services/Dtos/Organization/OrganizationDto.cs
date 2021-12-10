using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Organization
{
    public record OrganizationDto(
        int Id,
        string Name,
        List<ListingDto> Listings,
        List<ApplicationUserDto> Users,
        List<ArticleDto> Articles) : BaseDto(Id);
}
