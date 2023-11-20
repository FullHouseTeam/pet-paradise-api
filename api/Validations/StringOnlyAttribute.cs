using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class StringOnlyAttribute : ValidationAttribute, IModelValidator
{
    public void AddValidation(ClientModelValidationContext context)
    {
        // No es necesario para la validación del lado del cliente
    }

    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return true;
        }

        try
        {
            string? stringValue = value?.ToString();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
    {
        if (!IsValid(context.Model))
        {
            yield return new ModelValidationResult(context.ModelMetadata.PropertyName, ErrorMessage);
        }
    }
}
