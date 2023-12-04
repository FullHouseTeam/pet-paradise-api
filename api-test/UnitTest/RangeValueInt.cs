using System.ComponentModel.DataAnnotations;

namespace UnitTests 
{
    public class RangeValueIntTests
    {
        [Fact]
        public void ValidValueWithinRange()
        {
            var attribute = new RangeValueInt(1, 10);
            var validationResult = attribute.GetValidationResult(5, new ValidationContext(new object()));

            Assert.Equal(ValidationResult.Success, validationResult);
        }

        [Fact]
        public void ValidValueAtLowerBound()
        {
            var attribute = new RangeValueInt(1, 10);
            var validationResult = attribute.GetValidationResult(1, new ValidationContext(new object()));

            Assert.Equal(ValidationResult.Success, validationResult);
        }

        [Fact]
        public void ValidValueAtUpperBound()
        {
            var attribute = new RangeValueInt(1, 10);
            var validationResult = attribute.GetValidationResult(10, new ValidationContext(new object()));

            Assert.Equal(ValidationResult.Success, validationResult);
        }

        [Fact]
        public void InvalidValueBelowRange()
        {
            var attribute = new RangeValueInt(1, 10);
            var validationResult = attribute.GetValidationResult(0, new ValidationContext(new object()));

            Assert.NotEqual(ValidationResult.Success, validationResult);
            Assert.Equal(attribute.ErrorMessage, validationResult!.ErrorMessage);
        }

        [Fact]
        public void InvalidValueAboveRange()
        {
            var attribute = new RangeValueInt(1, 10);
            var validationResult = attribute.GetValidationResult(15, new ValidationContext(new object()));

            Assert.NotEqual(ValidationResult.Success, validationResult);
            Assert.Equal(attribute.ErrorMessage, validationResult!.ErrorMessage);
        }

        [Fact]
        public void NullValueIsValid()
        {
            var attribute = new RangeValueInt(1, 10);
            var validationResult = attribute.GetValidationResult(null, new ValidationContext(new object()));

            Assert.Equal(ValidationResult.Success, validationResult);
        }

        [Fact]
        public void NonIntValueIsValid()
        {
            var attribute = new RangeValueInt(1, 10);
            var validationResult = attribute.GetValidationResult("not an int", new ValidationContext(new object()));

            Assert.Equal(ValidationResult.Success, validationResult);
        }
    }
}
