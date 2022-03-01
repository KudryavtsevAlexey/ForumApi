using System;
using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;
using KudryavtsevAlexey.Forum.Services.Dtos.Subscriber;

namespace KudryavtsevAlexey.Forum.Services.Dtos.User
{
    public record ApplicationUserDto(
        int Id,
        string UserName,
        string Name,
        string Summary,
        string Location,
        string Email,
        DateTime JoinedAt,
        List<ArticleDto> Articles,
        List<ListingDto> Listings,
        List<SubscriberDto> Subscribers,
        List<SubscriptionDto> Subscriptions,
        int OrganizationId,
        OrganizationDto Organization) : BaseDto(Id);
}
