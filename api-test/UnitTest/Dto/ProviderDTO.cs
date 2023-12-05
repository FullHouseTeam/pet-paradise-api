using System.ComponentModel.DataAnnotations;
using api.DTOs;
using Xunit;

namespace api_test.UnitTest.DTOs
{
    public class ProviderDTOTest
    {
        [Fact]
        public void ProviderDTOProperties_ShouldWorkCorrectly()
        {
            var providerDTO = new ProviderDTO
            {
                ProviderID = 1,
                Name = "Test Provider",
                Nationality = "Test Nationality",
                IsAvailable = true
            };

            Assert.Equal(1, providerDTO.ProviderID);
            Assert.Equal("Test Provider", providerDTO.Name);
            Assert.Equal("Test Nationality", providerDTO.Nationality);
            Assert.True(providerDTO.IsAvailable);
        }

        [Fact]
        public void ProviderDTOValidation_ShouldFailForInvalidData()
        {
            var invalidProviderDTO = new ProviderDTO
            {
                ProviderID = -31,
                Name = "Test Provider Pr123ovider Provider Provider Provider Provider Provider Provider",
                Nationality = "Test 123Nationality Nationality Nationality Nationality Nationality",
                IsAvailable = true
            };

            var validationResults = ValidateModel(invalidProviderDTO);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void ProviderDTOValidation_ShouldPassForValidData()
        {
            var validProviderDTO = new ProviderDTO
            {
                ProviderID = 1,
                Name = "Test Provider",
                Nationality = "Test Nationality",
                IsAvailable = true
            };

            var validationResults = ValidateModel(validProviderDTO);
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
