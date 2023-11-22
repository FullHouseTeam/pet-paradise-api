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

        return ValidationResult.Success!;
    }
}
