using FluentValidation;
using FluentValidation.Validators;

namespace KudryavtsevAlexey.Forum.Services.Validation.BaseValidators
{
    public class IdValidator<T> : PropertyValidator<T, int>
    {
        private readonly string _fieldName;

        public IdValidator(string fieldName)
        {
            _fieldName = fieldName;
        }


        public override bool IsValid(ValidationContext<T> context, int value)
        {
            if (value>0)
            {
                return true;
            }

            context.AddFailure(_fieldName, $"{_fieldName} must be greater then 0");
            return false;
        }

        public override string Name { get; } = nameof(IdValidator<T>);
    }
}
