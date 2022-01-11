using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;

namespace KudryavtsevAlexey.Forum.Services.Validation.Article
{
	public class UpdateArticleDtoValidator : AbstractValidator<UpdateArticleDto>
    {
        public UpdateArticleDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(2);
            RuleFor(x => x.ShortDescription).NotEmpty().MinimumLength(5).NotEqual(x => x.Title);
            RuleFor(x => x.Tags.Count).GreaterThan(0);
        }
    }
}
