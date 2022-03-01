using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using KudryavtsevAlexey.Forum.Services.Validation.BaseValidators;

namespace KudryavtsevAlexey.Forum.Services.Validation.Comment
{
    public class CreateListingSubCommentDtoValidator : AbstractValidator<CreateListingSubCommentDto>
    {
        public CreateListingSubCommentDtoValidator()
        {
            RuleFor(x => x.UserId).SetValidator(new IdValidator<CreateListingSubCommentDto>("User id"));
            RuleFor(x => x.ListingId).SetValidator(new IdValidator<CreateListingSubCommentDto>("Listing id"));
            RuleFor(x => x.Content).NotEmpty().MinimumLength(30);
        }
    }
}
