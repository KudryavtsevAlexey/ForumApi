using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Validation.User
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Location).NotEmpty().MinimumLength(2);
            RuleFor(x => x.OrganizationName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Password).Equal(x => x.ConfirmedPassword);
            RuleFor(x => x.Email).SetValidator(new BaseValidators.EmailValidator<RegisterUserDto>("Email"));
        }
    }
}
