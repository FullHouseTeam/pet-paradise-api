using System.ComponentModel.DataAnnotations;

public class RequiredAttributeTests
{
    [Fact]
    public void RequiredAttribute_WhenValueIsNull_ShouldReturnError()
    {
        var attribute = new RequiredAttribute("Field");
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(null, validationContext);
        Assert.Equal(attribute.ErrorMessage, result!.ErrorMessage);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    public void RequiredAttribute_WhenValueIsNullOrWhiteSpace_ShouldReturnError(string value)
    {
        var attribute = new RequiredAttribute("Field");
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal(attribute.ErrorMessage, result!.ErrorMessage);
    }

    [Theory]
    [InlineData("some value")]
    [InlineData("123")]
    public void RequiredAttribute_WhenValueIsProvided_ShouldReturnSuccess(string value)
    {
        var attribute = new RequiredAttribute("Field");
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }
}
