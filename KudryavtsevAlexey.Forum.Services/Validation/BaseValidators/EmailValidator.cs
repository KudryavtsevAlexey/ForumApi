using FluentValidation;
using FluentValidation.Validators;

namespace KudryavtsevAlexey.Forum.Services.Validation.BaseValidators
{
    public class EmailValidator<T> : PropertyValidator<T, string>
    {
        private readonly string _fieldName;

        public EmailValidator(string fieldName)
        {
            _fieldName = fieldName;
        }

        public override bool IsValid(ValidationContext<T> context, string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false;
            }
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                context.AddFailure(_fieldName, $"{_fieldName} must be match email pattern");
                return false;
            }
        }

        public override string Name { get; } = nameof(EmailValidator<T>);
    }
}
