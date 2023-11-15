
using System.ComponentModel.DataAnnotations;
public class IntValueAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is not null)
        {
            if (int.TryParse(value.ToString(), out _))
            {
                return ValidationResult.Success!;
            }
            else
            {
                return new ValidationResult(ErrorMessage ?? "El valor debe ser un número entero.");
            }
        }

        return ValidationResult.Success!;
    }
}
