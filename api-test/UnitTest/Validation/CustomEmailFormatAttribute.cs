using System.ComponentModel.DataAnnotations;

public class CustomEmailFormatAttributeTests
{
    [Fact]
    public void CustomEmailFormatAttribute_WhenValueIsNull_ShouldReturnSuccess()
    {
        var attribute = new CustomEmailFormatAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(null, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("user@gmail.com")]
    [InlineData("john.doe@gmail.com")]
    [InlineData("user123@gmail.com")]
    public void CustomEmailFormatAttribute_WhenValidEmailFormat_ShouldReturnSuccess(string value)
    {
        var attribute = new CustomEmailFormatAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("user@yahoo.com")]
    [InlineData("john.doe@hotmail.com")]
    [InlineData("invalidemail")]
    [InlineData("user@gmail")]
    public void CustomEmailFormatAttribute_WhenInvalidEmailFormat_ShouldReturnError(string value)
    {
        var attribute = new CustomEmailFormatAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal(attribute.ErrorMessage, result!.ErrorMessage);
    }
}
