using System.ComponentModel.DataAnnotations;

public class CreditCardFormatAttributeTests
{
    [Fact]
    public void CreditCardFormatAttribute_WhenValueIsNull_ShouldReturnSuccess()
    {
        var attribute = new CreditCardFormatAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(null, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("1234-5678-9012-3456")]
    [InlineData("1111-2222-3333-4444")]
    [InlineData("9999-8888-7777-6666")]
    public void CreditCardFormatAttribute_WhenValidCreditCardFormat_ShouldReturnSuccess(string value)
    {
        var attribute = new CreditCardFormatAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("1234567890123456")]
    [InlineData("abcd-efgh-ijkl-mnop")]
    [InlineData("1111-2222-3333-444")]
    [InlineData("9876-5432-1098-7654-3210")]
    public void CreditCardFormatAttribute_WhenInvalidCreditCardFormat_ShouldReturnError(string value)
    {
        var attribute = new CreditCardFormatAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal(attribute.ErrorMessage, result!.ErrorMessage);
    }
}
