using System.ComponentModel.DataAnnotations;

public class DefaultValueAttribute : ValidationAttribute
{
    private readonly object _defaultValue;

    public DefaultValueAttribute(object defaultValue)
    {
        _defaultValue = defaultValue;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success!;
        }

        if (value.GetType() != _defaultValue.GetType())
        {
            return new ValidationResult("El valor predeterminado debe ser del mismo tipo que el valor.");
        }

        return ValidationResult.Success!;
    }
}
