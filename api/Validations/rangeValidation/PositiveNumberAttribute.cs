using System.ComponentModel.DataAnnotations;
using api.Utilities;

public class PositiveNumberAttribute : ValidationAttribute
{
    public PositiveNumberAttribute(string value)
    {
        ErrorMessage = ErrorUtilities.PositiveNumber(value);
    }
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success!;
        }

        if (value is IComparable comparableValue && comparableValue.CompareTo(0) < 1)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success!;
    }
}
