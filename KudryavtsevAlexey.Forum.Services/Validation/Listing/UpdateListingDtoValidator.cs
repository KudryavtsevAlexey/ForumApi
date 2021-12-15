using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;

namespace KudryavtsevAlexey.Forum.Services.Validation.Listing
{
    public class UpdateListingDtoValidator : AbstractValidator<UpdateListingDto>
    {
        public UpdateListingDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Category).NotEmpty().MinimumLength(2);
            RuleFor(x => x.ShortDescription).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Tags.Count).GreaterThan(0);
        }
    }
}
