using System.ComponentModel.DataAnnotations;
using api.Utilities;

public class MaxLengthCharacters : ValidationAttribute
{
    private readonly int _maxLength;

    public MaxLengthCharacters(int maxLength)
    {
        _maxLength = maxLength;
        ErrorMessage = ErrorUtilities.MaxLengthErrorMessage(maxLength);
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
      return ValidationResult.Success!;
    }
}