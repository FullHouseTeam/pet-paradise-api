using System.ComponentModel.DataAnnotations;
using Xunit;

public class NoSpecialCharactersAttributeTests
{
    [Theory]
    [InlineData("ValidInput123")]
    [InlineData("NoSpecialChars")]
    [InlineData("123 456")]
    public void NoSpecialCharacters_WhenInputIsValid_ShouldReturnSuccess(string value)
    {
        var attribute = new NoSpecialCharactersAttribute("test");
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(value, validationContext);

        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("Invalid!@#")]
    [InlineData("Special^Chars")]
    [InlineData("1$2%3")]
    public void NoSpecialCharacters_WhenInputContainsSpecialCharacters_ShouldReturnError(string value)
    {
        var attribute = new NoSpecialCharactersAttribute("test");
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(value, validationContext);

        Assert.Equal(attribute.ErrorMessage, result!.ErrorMessage);
    }

    [Fact]
    public void NoSpecialCharacters_WhenValueIsNull_ShouldReturnSuccess()
    {
        var attribute = new NoSpecialCharactersAttribute("test");
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(null, validationContext);

        Assert.Equal(ValidationResult.Success, result);
    }
}
