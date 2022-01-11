using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;

namespace KudryavtsevAlexey.Forum.Services.Dtos.User
{
    public record ApplicationUserDto(
        int Id,
        string UserName,
        string Name,
        string Summary,
        string Location,
        DateTime JoinedAt,
        List<ArticleDto> Articles,
        List<ListingDto> Listings,
        List<SubscriberDto> Subscribers,
        int OrganizationId,
        OrganizationDto Organization) : BaseDto(Id);
}
