using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using api.Utilities;

public class NoSpecialCharactersAttribute : ValidationAttribute
{
    public NoSpecialCharactersAttribute(string value)
    {
        ErrorMessage = ErrorUtilities.NoSpecialCharacters(value);
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string stringValue = value.ToString();
            // Patrón regex para permitir letras, números y espacios
            var regex = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regex.IsMatch(stringValue))
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }
}
