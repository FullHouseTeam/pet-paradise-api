using System;
using System.ComponentModel.DataAnnotations;
using api.DTOs;
using Xunit;

namespace api_test.UnitTest.DTOs
{
    public class BrandDTOTest
    {
        [Fact]
        public void BrandDTOProperties_ShouldWorkCorrectly()
        {
            var brandDTO = new BrandDTO
            {
                BrandID = 1,
                Name = "Test Brand",
                Logo = "https://example.com/logo.png",
                IsAvailable = true
            };

            Assert.Equal(1, brandDTO.BrandID);
            Assert.Equal("Test Brand", brandDTO.Name);
            Assert.Equal("https://example.com/logo.png", brandDTO.Logo);
            Assert.True(brandDTO.IsAvailable);
        }

        [Fact]
        public void BrandDTOValidation_ShouldFailForInvalidData()
        {
            var invalidBrandDTO = new BrandDTO
            {
                BrandID = 1,
                Name = "Invalid Brand 123",
                Logo = "invalid-url",
                IsAvailable = false
            };

            var validationResults = ValidateModel(invalidBrandDTO);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void BrandDTOValidation_ShouldPassForValidData()
        {
            var validBrandDTO = new BrandDTO
            {
                BrandID = 1,
                Name = "Valid Brand",
                Logo = "https://example.com/valid-logo.png",
                IsAvailable = true
            };

            var validationResults = ValidateModel(validBrandDTO);
            Assert.Empty(validationResults);
        }

        private static System.Collections.Generic.IEnumerable<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
