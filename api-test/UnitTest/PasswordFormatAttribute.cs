using System.ComponentModel.DataAnnotations;
using Xunit;

public class PasswordFormatAttributeTests
{
    [Theory]
    [InlineData("A1bcdefg")]
    [InlineData("X9uvwxyz")]
    public void PasswordFormat_WhenFormatIsCorrect_ShouldReturnSuccess(string value)
    {
        var attribute = new PasswordFormatAttribute();
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(value, validationContext);

        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("A1b")]
    [InlineData("1234567")]
    [InlineData("A1bcdefgH")] 
    public void PasswordFormat_WhenFormatIsIncorrect_ShouldReturnError(string value)
    {
        var attribute = new PasswordFormatAttribute();
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(value, validationContext);

        Assert.Equal(new ValidationResult(attribute.ErrorMessage), result);
    }

    [Fact]
    public void PasswordFormat_WhenValueIsNull_ShouldReturnSuccess()
    {
        var attribute = new PasswordFormatAttribute();
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(null, validationContext);

        Assert.Equal(ValidationResult.Success, result);
    }
}
