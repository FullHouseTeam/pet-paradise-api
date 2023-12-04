using System.ComponentModel.DataAnnotations;
using Xunit;

public class OnlyNumbersAttributeTests
{
    [Theory]
    [InlineData("12345")]
    [InlineData("987654")]
    public void OnlyNumbers_WhenInputContainsOnlyNumbers_ShouldReturnSuccess(string value)
    {
        var attribute = new OnlyNumbersAttribute();
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(value, validationContext);

        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("12.34")]
    [InlineData("1a2b3c")]
    public void OnlyNumbers_WhenInputContainsNonNumbers_ShouldReturnError(string value)
    {
        var attribute = new OnlyNumbersAttribute();
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(value, validationContext);

        Assert.Equal(attribute.ErrorMessage, result!.ErrorMessage);
    }

    [Fact]
    public void OnlyNumbers_WhenValueIsNull_ShouldReturnSuccess()
    {
        var attribute = new OnlyNumbersAttribute();
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(null, validationContext);

        Assert.Equal(ValidationResult.Success, result);
    }
}
