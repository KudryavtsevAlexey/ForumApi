using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Validation.BaseValidators;

namespace KudryavtsevAlexey.Forum.Services.Validation.Article
{
    public class CreateArticleDtoValidator : AbstractValidator<CreateArticleDto>
    {
        public CreateArticleDtoValidator()
        {
            RuleFor(x => x.UserId).SetValidator(new IdValidator<CreateArticleDto>("User id"));
            RuleFor(x => x.OrganizationId).SetValidator(new IdValidator<CreateArticleDto>("Organization id"));
            RuleFor(x => x.Title).NotEmpty().MinimumLength(2);
            RuleFor(x => x.ShortDescription).NotEmpty().MinimumLength(2).NotEqual(x => x.Title);
            RuleFor(x => x.Tags.Count).GreaterThan(0);
        }
    }
}
