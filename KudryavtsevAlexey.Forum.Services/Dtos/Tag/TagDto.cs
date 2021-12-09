using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Tag
{
    public record TagDto(
        int Id,
        string Name,
        List<ArticleDto> Articles,
        List<ListingDto> Listings) : BaseDto(Id);
}
