using System.ComponentModel.DataAnnotations;

public class DefaultValueAttribute : ValidationAttribute
{
    private readonly object _defaultValue;

    public DefaultValueAttribute(object defaultValue)
    {
        _defaultValue = defaultValue;
    }

    public override bool RequiresValidationContext => true;

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var memberName = validationContext.MemberName;

        if (memberName != null)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(memberName);

            if (propertyInfo != null && propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(validationContext.ObjectInstance, _defaultValue);
            }
        }

        return ValidationResult.Success!;
    }
}
