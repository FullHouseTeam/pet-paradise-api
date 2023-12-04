using System.ComponentModel.DataAnnotations;
using Xunit;

public class HttpsUrlAttributeTests
{
    [Fact]
    public void HttpsUrlAttribute_WhenValueIsNull_ShouldReturnSuccess()
    {
        var attribute = new HttpsUrlAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(null, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("https://example.com")]
    [InlineData("HTTPS://example.com")]
    [InlineData("https://subdomain.example.com")]
    public void HttpsUrlAttribute_WhenValueStartsWithHttps_ShouldReturnSuccess(string value)
    {
        var attribute = new HttpsUrlAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal(ValidationResult.Success, result);
    }

    [Theory]
    [InlineData("http://example.com")]
    [InlineData("ftp://example.com")]
    [InlineData("example.com")]
    public void HttpsUrlAttribute_WhenValueDoesNotStartWithHttps_ShouldReturnError(string value)
    {
        var attribute = new HttpsUrlAttribute();
        var validationContext = new ValidationContext(new object());
        var result = attribute.GetValidationResult(value, validationContext);
        Assert.Equal(attribute.ErrorMessage ?? "The URL must start with 'https:'.", result!.ErrorMessage);
    }
}
