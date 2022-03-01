using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.User;
using KudryavtsevAlexey.Forum.Services.Validation.BaseValidators;

namespace KudryavtsevAlexey.Forum.Services.Validation.User
{
    public class SignInUserDtoValidator : AbstractValidator<SignInUserDto>
    {
        public SignInUserDtoValidator()
        {
            RuleFor(x => x.Email).SetValidator(new EmailValidator<SignInUserDto>("Email"));
        }
    }
}
