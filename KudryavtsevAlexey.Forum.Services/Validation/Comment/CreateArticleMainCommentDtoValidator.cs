using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using KudryavtsevAlexey.Forum.Services.Validation.BaseValidators;

namespace KudryavtsevAlexey.Forum.Services.Validation.Comment
{
    public class CreateArticleMainCommentDtoValidator : AbstractValidator<CreateArticleMainCommentDto>
    {
        public CreateArticleMainCommentDtoValidator()
        {
            RuleFor(x => x.ArticleId).SetValidator(new IdValidator<CreateArticleMainCommentDto>("Article id"));
            RuleFor(x => x.UserId).NotNull().GreaterThan(0).SetValidator(new IdValidator<CreateArticleMainCommentDto>("User id"));
            RuleFor(x => x.Content).NotEmpty().MinimumLength(30);
        }
    }
}
