using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Tag
{
    public record UpdateTagDto(
	    int Id,
	    string Name) : BaseDto(Id);
}
