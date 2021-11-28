using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record TagDto(
        int Id,
        string Name,
        List<ArticleDto> Articles,
        List<ListingDto> Listings) : BaseDto(Id);
}
