using System.ComponentModel.DataAnnotations;


namespace api.Models.Tests
{
    public class DecimalPrecisionTests
    {
        [Theory]
        [InlineData(12.3456, 1)]
        [InlineData(123.456, 2)]
        [InlineData(1234.5678, 3)]
        public void DecimalPrecision_WhenInvalidPrecision_ShouldReturnError(decimal value, int precision)
        {
            var attribute = new DecimalPrecision(precision);
            var validationContext = new ValidationContext(new { Value = value }) { DisplayName = "Value" };
            var result = attribute.GetValidationResult(value, validationContext);
            Assert.Equal($"The 'Value' property must have up to {precision} decimal places.", result!.ErrorMessage);
        }

        [Fact]
        public void DecimalPrecision_WhenValueIsNull_ShouldReturnSuccess()
        {
            var attribute = new DecimalPrecision(2);
            var validationContext = new ValidationContext(new { Value = (decimal?)null }) { DisplayName = "Value" };
            var result = attribute.GetValidationResult(null, validationContext);
            Assert.Equal(ValidationResult.Success, result);
        }
    }
}
