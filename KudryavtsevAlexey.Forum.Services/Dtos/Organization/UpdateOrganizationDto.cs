using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Organization
{
    public record UpdateOrganizationDto(
	    int Id,
	    string Name) : BaseDto(Id);
}
