using System.ComponentModel.DataAnnotations;

public class DecimalValueTests
{
    [Fact]
    public void DecimalValue_WhenValueIsNull_ShouldReturnSuccess()
    {
        var attribute = new DecimalValue();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(null, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("123.45")]
    [InlineData("-67.89")]
    [InlineData("0.0")]
    public void DecimalValue_WhenValidDecimal_ShouldReturnSuccess(string value)
    {
        var attribute = new DecimalValue();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("12.34.56")]
    [InlineData("notADecimal")]
    [InlineData("   ")]
    public void DecimalValue_WhenInvalidDecimal_ShouldReturnError(string value)
    {
        var attribute = new DecimalValue();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal("The value must be a decimal number.", result!.ErrorMessage);
    }
}
