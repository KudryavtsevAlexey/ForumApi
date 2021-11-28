using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record UserDto(
        int Id,
        string UserName,
        string Name,
        string Summary,
        string Location,
        DateTime JoinedAt,
        List<ArticleDto> Articles,
        List<SubscriberDto> Subscribers,
        List<ListingDto> Listings,
        int OrganizationId,
        OrganizationDto Organization,
        string ImageUrl) : BaseDto(Id);
}
