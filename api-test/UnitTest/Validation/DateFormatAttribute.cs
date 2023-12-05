using System.ComponentModel.DataAnnotations;

public class DateFormatAttributeTests
{
    [Fact]
    public void DateFormatAttribute_WhenValueIsNull_ShouldReturnSuccess()
    {
        var attribute = new DateFormatAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(null, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("01/2023")]
    [InlineData("12/2022")]
    public void DateFormatAttribute_WhenValidDateFormat_ShouldReturnSuccess(string value)
    {
        var attribute = new DateFormatAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("2023/01")]
    [InlineData("13/2022")]
    [InlineData("01/22")]
    [InlineData("01/abcd")]
    public void DateFormatAttribute_WhenInvalidDateFormat_ShouldReturnError(string value)
    {
        var attribute = new DateFormatAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal(attribute.ErrorMessage, result!.ErrorMessage);
    }
}
