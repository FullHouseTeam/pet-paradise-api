using System.ComponentModel.DataAnnotations;
using api.DTOs;
using Xunit;

namespace api_test.UnitTest.DTOs
{
    public class ReviewDTOTest
    {
        [Fact]
        public void ReviewDTOProperties_ShouldWorkCorrectly()
        {
            var reviewDTO = new ReviewDTO
            {
                ReviewID = 1,
                CustomerID = 2,
                ProductID = 3,
                ReviewMessage = "Test review message"
            };

            Assert.Equal(1, reviewDTO.ReviewID);
            Assert.Equal(2, reviewDTO.CustomerID);
            Assert.Equal(3, reviewDTO.ProductID);
            Assert.Equal("Test review message", reviewDTO.ReviewMessage);
        }

        [Fact]
        public void ReviewDTOValidation_ShouldFailForInvalidData()
        {
            var invalidReviewDTO = new ReviewDTO
            {
                ReviewID = 1,
                CustomerID = 2,
                ProductID = 3,
                ReviewMessage = "Test revi|dsf@2ew message"
            };

            var validationResults = ValidateModel(invalidReviewDTO);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void ReviewDTOValidation_ShouldPassForValidData()
        {
            var validReviewDTO = new ReviewDTO
            {
                ReviewID = 1,
                CustomerID = 2,
                ProductID = 3,
                ReviewMessage = "Test review message"
            };

            var validationResults = ValidateModel(validReviewDTO);
            Assert.Empty(validationResults);
        }

        private static IEnumerable<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
