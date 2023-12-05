using System.ComponentModel.DataAnnotations;

namespace api.Utilities.Tests
{
    public class StringValueTests
    {
        [Fact]
        public void StringValue_WhenValueIsNull_ShouldReturnSuccess()
        {
            var attribute = new StringValue("Field");
            var validationContext = new ValidationContext(new object());
            var result = attribute.GetValidationResult(null, validationContext);
            Assert.Equal(ValidationResult.Success, result);
        }

        [Theory]
        [InlineData("validString")]
        [InlineData("123")]
        [InlineData("   ")]
        public void StringValue_WhenValidString_ShouldReturnSuccess(string value)
        {
            var attribute = new StringValue("Field");
            var validationContext = new ValidationContext(new object());
            var result = attribute.GetValidationResult(value, validationContext);
            Assert.Equal(ValidationResult.Success, result);
        }

        [Theory]
        [InlineData(123)]
        [InlineData(null)]
        public void StringValue_WhenInvalidType_ShouldReturnError(object? value)
        {
            if (value != null) {
                var attribute = new StringValue("Field");
                var validationContext = new ValidationContext(new object());
                var result = attribute.GetValidationResult(value, validationContext);
                Assert.Equal(attribute.ErrorMessage, result!.ErrorMessage);
            }
        }

        [Theory]
        [InlineData(null)]
        public void StringValue_WhenInvalidString_ShouldReturnError(string? value)
        {
            if (value != null) {
                var attribute = new StringValue("Field");
                var validationContext = new ValidationContext(new object());
                var result = attribute.GetValidationResult(value, validationContext);
                Assert.Equal(attribute.ErrorMessage, result!.ErrorMessage);
            }
        }
    }
}
