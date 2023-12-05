using System.ComponentModel.DataAnnotations;

public class NoNumbersAttributeTests
{
    [Theory]
    [InlineData("ValidInput")]
    [InlineData("NoNumbers")]
    [InlineData("OnlyLetters")]
    public void NoNumbers_WhenInputIsValid_ShouldReturnSuccess(string value)
    {
        var attribute = new NoNumbersAttribute("test");
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(value, validationContext);

        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("Contains123")]
    [InlineData("12345")]
    [InlineData("1 2 3")]
    public void NoNumbers_WhenInputContainsNumbers_ShouldReturnError(string value)
    {
        var attribute = new NoNumbersAttribute("test");
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(value, validationContext);

        Assert.Equal("The (test) field must not contain numbers", result!.ErrorMessage);
    }

    [Fact]
    public void NoNumbers_WhenValueIsNull_ShouldReturnSuccess()
    {
        var attribute = new NoNumbersAttribute("test");
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(null, validationContext);

        Assert.Equal(ValidationResult.Success, result);
    }
}
