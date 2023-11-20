#nullable disable
using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class StringValue : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return new ValidationResult("El campo no debe ser nulo.");
        }

        if (value is not string)
        {
            return new ValidationResult("El campo debe ser un string.");
        }

        return ValidationResult.Success;
    }
}
