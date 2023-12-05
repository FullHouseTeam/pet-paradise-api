using System.ComponentModel.DataAnnotations;

public class BooleanValueAttributeTests
{
    [Fact]
    public void BooleanValueAttribute_WhenValueIsNull_ShouldReturnSuccess()
    {
        var attribute = new BooleanValueAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(null, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("true")]
    [InlineData("True")]
    [InlineData("false")]
    [InlineData("False")]
    public void BooleanValueAttribute_WhenValidBoolean_ShouldReturnSuccess(string value)
    {
        var attribute = new BooleanValueAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("notABoolean")]
    [InlineData("   ")]
    public void BooleanValueAttribute_WhenInvalidBoolean_ShouldReturnError(string value)
    {
        var attribute = new BooleanValueAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal("The value must be a valid boolean.", result!.ErrorMessage);
    }
}
