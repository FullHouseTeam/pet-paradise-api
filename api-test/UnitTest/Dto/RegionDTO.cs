using System.ComponentModel.DataAnnotations;
using api.DTOs;
using Xunit;

namespace api_test.UnitTest.DTOs
{
    public class RegionDTOTest
    {
        [Fact]
        public void RegionDTOProperties_ShouldWorkCorrectly()
        {
            var regionDTO = new RegionDTO
            {
                RegionID = 1,
                Name = "Test Region",
                MunicipalTax = 10.5m,
                StatalTax = 5.2m
            };

            Assert.Equal(1, regionDTO.RegionID);
            Assert.Equal("Test Region", regionDTO.Name);
            Assert.Equal(10.5m, regionDTO.MunicipalTax);
            Assert.Equal(5.2m, regionDTO.StatalTax);
        }

        [Fact]
        public void RegionDTOValidation_ShouldFailForInvalidData()
        {
            var invalidRegionDTO = new RegionDTO
            {
                RegionID = 1,
                Name = "Tes@a123t Region",
                MunicipalTax = 10.5m,
                StatalTax = 5.2m
            };

            var validationResults = ValidateModel(invalidRegionDTO);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void RegionDTOValidation_ShouldPassForValidData()
        {
            var validRegionDTO = new RegionDTO
            {
                RegionID = 1,
                Name = "Test Region",
                MunicipalTax = 10.5m,
                StatalTax = 5.2m
            };

            var validationResults = ValidateModel(validRegionDTO);
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
