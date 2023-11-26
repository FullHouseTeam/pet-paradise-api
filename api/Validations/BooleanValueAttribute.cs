using System;
using System.ComponentModel.DataAnnotations;

public class BooleanValueAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not null)
        {
            if (bool.TryParse(value.ToString(), out _))
            {
                return ValidationResult.Success!;
            }
            else
            {
                return new ValidationResult(ErrorMessage ?? "The value must be a valid boolean.");
            }
        }

        return ValidationResult.Success!;
    }
}
