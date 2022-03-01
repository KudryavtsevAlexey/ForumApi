using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;

namespace KudryavtsevAlexey.Forum.Services.Validation.Organization
{
    public class UpdateOrganizationDtoValidator : AbstractValidator<UpdateOrganizationDto>
    {
        public UpdateOrganizationDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
        }
    }
}
