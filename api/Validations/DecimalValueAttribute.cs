
using System.ComponentModel.DataAnnotations;

public class DecimalValueAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is not null)
        {
            if (decimal.TryParse(value.ToString(), out _))
            {
                return ValidationResult.Success!;
            }
            else
            {
                return new ValidationResult(ErrorMessage ?? "El valor debe ser un número decimal.");
            }
        }

        return ValidationResult.Success!;
    }
}
