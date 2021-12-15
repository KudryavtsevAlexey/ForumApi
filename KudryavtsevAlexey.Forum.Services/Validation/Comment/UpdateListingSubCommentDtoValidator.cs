using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;

namespace KudryavtsevAlexey.Forum.Services.Validation.Comment
{
    public class UpdateListingSubCommentDtoValidator : AbstractValidator<UpdateListingSubCommentDto>
    {
        public UpdateListingSubCommentDtoValidator()
        {
            RuleFor(x => x.Content).NotEmpty().MinimumLength(30);
        }
    }
}
