using System.ComponentModel.DataAnnotations;
using api.Utilities;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace UnitTests 
{
    public class RangeValueDecimalTests
    {
        [Fact]
        public void ValidValueWithinRange()
        {
            var attribute = new RangeValueDecimal(1.0, 10.0);
            var validationResult = attribute.GetValidationResult(5.0, new ValidationContext(new object()));

            Assert.Equal(ValidationResult.Success, validationResult);
        }

        [Fact]
        public void ValidValueAtLowerBound()
        {
            var attribute = new RangeValueDecimal(1.0, 10.0);
            var validationResult = attribute.GetValidationResult(1.0, new ValidationContext(new object()));

            Assert.Equal(ValidationResult.Success, validationResult);
        }

        [Fact]
        public void ValidValueAtUpperBound()
        {
            var attribute = new RangeValueDecimal(1.0, 10.0);
            var validationResult = attribute.GetValidationResult(10.0, new ValidationContext(new object()));

            Assert.Equal(ValidationResult.Success, validationResult);
        }

        [Fact]
        public void InvalidValueBelowRange()
        {
            var attribute = new RangeValueDecimal(1.0, 10.0);
            var validationResult = attribute.GetValidationResult(0.5, new ValidationContext(new object()));

            Assert.NotEqual(ValidationResult.Success, validationResult);
            Assert.Equal("The value must be greater than or equal to 1.0 and less than 10.0.", validationResult.ErrorMessage);
        }

        [Fact]
        public void InvalidValueAboveRange()
        {
            var attribute = new RangeValueDecimal(1.0, 10.0);
            var validationResult = attribute.GetValidationResult(15.0, new ValidationContext(new object()));

            Assert.NotEqual(ValidationResult.Success, validationResult);
            Assert.Equal("The value must be greater than or equal to 1.0 and less than 10.0.", validationResult.ErrorMessage);
        }

        [Fact]
        public void NullValueIsValid()
        {
            var attribute = new RangeValueDecimal(1.0, 10.0);
            var validationResult = attribute.GetValidationResult(null, new ValidationContext(new object()));

            Assert.Equal(ValidationResult.Success, validationResult);
        }

        [Fact]
        public void NonDecimalValueIsInvalid()
        {
            var attribute = new RangeValueDecimal(1.0, 10.0);
            var validationResult = attribute.GetValidationResult("not a decimal", new ValidationContext(new object()));

            Assert.NotEqual(ValidationResult.Success, validationResult);
            Assert.Equal("The value is not a valid number.", validationResult.ErrorMessage);
        }
    }
}
