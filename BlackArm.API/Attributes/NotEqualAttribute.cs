using System.ComponentModel.DataAnnotations;

namespace BlackArm.API.Attributes
{
    public class NotEqualAttribute : ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public NotEqualAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty(_otherPropertyName);
            if (otherProperty == null)
            {
                return new ValidationResult($"Unknown property {_otherPropertyName}");
            }

            var otherValue = otherProperty.GetValue(validationContext.ObjectInstance);

            if (value != null && otherValue != null && value.Equals(otherValue))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

    }
}
