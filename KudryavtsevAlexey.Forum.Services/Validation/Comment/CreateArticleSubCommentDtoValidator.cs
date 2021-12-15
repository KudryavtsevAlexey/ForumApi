using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using KudryavtsevAlexey.Forum.Services.Validation.BaseValidators;

namespace KudryavtsevAlexey.Forum.Services.Validation.Comment
{
    public class CreateArticleSubCommentDtoValidator : AbstractValidator<CreateArticleSubCommentDto>
    {
        public CreateArticleSubCommentDtoValidator()
        {
            RuleFor(x => x.UserId).SetValidator(new IdValidator<CreateArticleSubCommentDto>("User id"));
            RuleFor(x => x.ArticleId).NotNull().SetValidator(new IdValidator<CreateArticleSubCommentDto>("Article"));
            RuleFor(x => x.ArticleMainCommentId).SetValidator(new IdValidator<CreateArticleSubCommentDto>("Article main comment id"));
            RuleFor(x => x.Content).NotEmpty().MinimumLength(30);
        }
    }
}
