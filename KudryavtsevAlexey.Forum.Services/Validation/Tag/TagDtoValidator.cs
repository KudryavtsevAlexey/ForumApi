using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using KudryavtsevAlexey.Forum.Services.Validation.BaseValidators;

namespace KudryavtsevAlexey.Forum.Services.Validation.Tag
{
    public class TagDtoValidator : AbstractValidator<TagDto>
    {
        public TagDtoValidator()
        {
            RuleFor(x => x.Id).SetValidator(new IdValidator<TagDto>("Tag id"));
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
        }
    }
}
