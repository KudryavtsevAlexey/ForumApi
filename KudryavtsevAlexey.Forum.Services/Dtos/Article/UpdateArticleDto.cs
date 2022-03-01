using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Article
{
	public record UpdateArticleDto(
		int Id,
		string Title,
		string ShortDescription,
		List<TagDto> Tags) : BaseDto(Id);
}
