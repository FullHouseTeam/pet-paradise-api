using System.ComponentModel.DataAnnotations;

namespace UnitTests
{
    public class PositiveNumberAttributeTests
    {
        [Fact]
        public void ValidPositiveInteger()
        {
            var attribute = new PositiveNumberAttribute("FieldName");
            var validationResult = attribute.GetValidationResult(5, new ValidationContext(new object()));

            Assert.Equal(ValidationResult.Success, validationResult);
        }

        [Fact]
        public void ValidPositiveZero()
        {
            var attribute = new PositiveNumberAttribute("FieldName");
            var validationResult = attribute.GetValidationResult(0, new ValidationContext(new object()));

            Assert.Equal(attribute.ErrorMessage, validationResult!.ErrorMessage);
        }

        [Fact]
        public void InvalidNegativeInteger()
        {
            var attribute = new PositiveNumberAttribute("FieldName");
            var validationResult = attribute.GetValidationResult(-5, new ValidationContext(new object()));

            Assert.NotEqual(ValidationResult.Success, validationResult);
            Assert.Equal(attribute.ErrorMessage, validationResult!.ErrorMessage);
        }

        [Fact]
        public void InvalidZero()
        {
            var attribute = new PositiveNumberAttribute("FieldName");
            var validationResult = attribute.GetValidationResult(0, new ValidationContext(new object()));

            Assert.NotEqual(ValidationResult.Success, validationResult);
            Assert.Equal(attribute.ErrorMessage, validationResult!.ErrorMessage);
        }

        [Fact]
        public void ValidNullValue()
        {
            var attribute = new PositiveNumberAttribute("FieldName");
            var validationResult = attribute.GetValidationResult(null, new ValidationContext(new object()));

            Assert.Equal(ValidationResult.Success, validationResult);
        }
    }
}
