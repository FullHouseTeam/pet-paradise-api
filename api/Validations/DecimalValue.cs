using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class DecimalValueAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not null)
        {
            var stringValue = value.ToString();

            if (stringValue != null && Regex.IsMatch(stringValue, @"^\d+(\.\d+)?$"))
            {
                return ValidationResult.Success!;
            }
            else
            {
                return new ValidationResult(ErrorMessage ?? "The value must be a valid decimal number.");
            }
        }
        return ValidationResult.Success!;
    }
}
