using System.ComponentModel.DataAnnotations;
public class IntValue : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not null)
        {
            if (int.TryParse(value.ToString(), out _))
            {
                return ValidationResult.Success!;
            }
            else
            {
                return new ValidationResult(ErrorMessage ?? "The value must be an integer.");
            }
        }

        return ValidationResult.Success!;
    }
}