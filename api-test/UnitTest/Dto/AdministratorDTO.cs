using System.ComponentModel.DataAnnotations;
using api.DTOs.Entities;
using Xunit;

namespace api_test.UnitTest.DTOs.Entities
{
    public class AdministratorDTOTest
    {
        [Fact]
        public void AdministratorDTOProperties_ShouldWorkCorrectly()
        {
            var administratorDTO = new AdministratorDTO
            {
                Email = "admin@gmail.com",
                Password = "A4asdfew"
            };

            Assert.Equal("admin@gmail.com", administratorDTO.Email);
            Assert.Equal("A4asdfew", administratorDTO.Password);
        }

        [Fact]
        public void AdministratorDTOValidation_ShouldFailForInvalidData()
        {
            var invalidAdministratorDTO = new AdministratorDTO
            {
                Email = "invalid-email",
                Password = "short"
            };

            var validationResults = ValidateModel(invalidAdministratorDTO);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void AdministratorDTOValidation_ShouldPassForValidData()
        {
            var validAdministratorDTO = new AdministratorDTO
            {
                Email = "admin@gmail.com",
                Password = "A4asdfew"
            };

            var validationResults = ValidateModel(validAdministratorDTO);
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
