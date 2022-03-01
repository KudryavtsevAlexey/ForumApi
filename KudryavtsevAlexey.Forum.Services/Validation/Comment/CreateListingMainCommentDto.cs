using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using KudryavtsevAlexey.Forum.Services.Validation.BaseValidators;

namespace KudryavtsevAlexey.Forum.Services.Validation.Comment
{
    public class CreateListingMainCommentDtoValidator : AbstractValidator<CreateListingMainCommentDto>
    {
        public CreateListingMainCommentDtoValidator()
        {
            RuleFor(x => x.UserId).SetValidator(new IdValidator<CreateListingMainCommentDto>("User id"));
            RuleFor(x => x.ListingId).SetValidator(new IdValidator<CreateListingMainCommentDto>("Listing id"));
            RuleFor(x => x.Content).NotEmpty().MinimumLength(30);
        }
    }
}
