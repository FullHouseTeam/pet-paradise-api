
using System.ComponentModel.DataAnnotations;
using api.Utilities;
public class RangeValueDecimalAttribute : ValidationAttribute
{
    private readonly double _range1;
    private readonly double _range2;

    public RangeValueDecimalAttribute(double range1, double range2)
    {
        _range1 = range1;
        _range2 = range2;
        ErrorMessage = ErrorUtilities.RangeValueErrorMessageDecimal(range1, range2);
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is not null)
        {
            if (double.TryParse(value.ToString(), out double doubleValue))
            {
                if (doubleValue < _range1 || doubleValue >= _range2)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            else
            {
                return new ValidationResult("El valor no es un número válido.");
            }
        }
        return ValidationResult.Success!;
    }
}
