using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;

namespace KudryavtsevAlexey.Forum.Services.Validation.Organization
{
    public class CreateOrganizationDtoValidator : AbstractValidator<CreateOrganizationDto>
    {
        public CreateOrganizationDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
        }
    }
}
