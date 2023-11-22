#nullable disable
using System.ComponentModel.DataAnnotations;
public class StringValue : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return new ValidationResult("The field must not be null");
        }

        if (value is not string)
        {
            return new ValidationResult("The field must be a string.");
        }

        return ValidationResult.Success;
    }
}
