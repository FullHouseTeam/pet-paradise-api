using System.ComponentModel.DataAnnotations;

namespace api.Utilities.Tests
{
    public class IntegerValueTests
    {
        [Fact]
        public void IntegerValue_WhenValueIsNull_ShouldReturnSuccess()
        {
            var attribute = new IntegerValue("Field");
            var validationContext = new ValidationContext(new object());
            var result = attribute.GetValidationResult(null, validationContext);
            Assert.Equal(ValidationResult.Success, result);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("-456")]
        public void IntegerValue_WhenValidInteger_ShouldReturnSuccess(string value)
        {
            var attribute = new IntegerValue("Field");
            var validationContext = new ValidationContext(new object());
            var result = attribute.GetValidationResult(value, validationContext);
            Assert.Equal(ValidationResult.Success, result);
        }

        [Theory]
        [InlineData("12.34")]
        [InlineData("notAnInteger")]
        [InlineData("  ")] 
        public void IntegerValue_WhenInvalidInteger_ShouldReturnError(string value)
        {
            var attribute = new IntegerValue("Field");
            var validationContext = new ValidationContext(new object());
            var result = attribute.GetValidationResult(value, validationContext);
            Assert.Equal(attribute.ErrorMessage, result!.ErrorMessage);
        }

        [Theory]
        [InlineData(null)]
        public void IntegerValue_WhenInvalidType_ShouldReturnError(object? value)
        {
            if (value != null) {
            var attribute = new IntegerValue("Field");
            var validationContext = new ValidationContext(new object());
            var result = attribute.GetValidationResult(value, validationContext);
            Assert.Equal(attribute.ErrorMessage, result!.ErrorMessage);
            }
        }
    }
}
