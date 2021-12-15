using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Validation.BaseValidators;

namespace KudryavtsevAlexey.Forum.Services.Validation.Listing
{
    public class CreateListingDtoValidator : AbstractValidator<CreateListingDto>
    {
        public CreateListingDtoValidator()
        {
            RuleFor(x => x.UserId).SetValidator(new IdValidator<CreateListingDto>("User id"));
            RuleFor(x=>x.OrganizationId).SetValidator(new IdValidator<CreateListingDto>("Organization id"));
            RuleFor(x => x.Category).NotEmpty().MinimumLength(3);
            RuleFor(x => x.ShortDescription).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Title).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Tags.Count).GreaterThan(0);
        }
    }
}
