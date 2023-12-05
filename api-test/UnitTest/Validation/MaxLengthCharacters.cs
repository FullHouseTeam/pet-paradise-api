using System.ComponentModel.DataAnnotations;

public class MaxLengthCharactersTests
{
    [Fact]
    public void MaxLengthCharacters_WhenValueIsNull_ShouldReturnSuccess()
    {
        var attribute = new MaxLengthCharacters("example", 10);
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(null, validationContext);

        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("short", 10)]
    [InlineData("justright", 10)]
    public void MaxLengthCharacters_WhenValueIsWithinMaxLength_ShouldReturnSuccess(string value, int maxLength)
    {
        var attribute = new MaxLengthCharacters(value, maxLength);
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(value, validationContext);

        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("thisisaverylongstring", 10)]
    [InlineData("toolong", 5)]
    public void MaxLengthCharacters_WhenValueExceedsMaxLength_ShouldReturnError(string value, int maxLength)
    {
        var attribute = new MaxLengthCharacters(value, maxLength);
        var validationContext = new ValidationContext(new object());

        var result = attribute.GetValidationResult(value, validationContext);

        Assert.Equal(attribute.ErrorMessage, result!.ErrorMessage);
    }
}
