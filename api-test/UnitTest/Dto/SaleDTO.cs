using System.ComponentModel.DataAnnotations;
using api.DTOs.Entities;
using Xunit;

namespace api_test.UnitTest.DTOs.Entities
{
    public class SaleDTOTest
    {
        [Fact]
        public void SaleDTOProperties_ShouldWorkCorrectly()
        {
            var saleDTO = new SaleDTO
            {
                SaleID = 1,
                ZipCode = "12345",
                Cvv = 123,
                CardNumber = "1234-5678-9012-3456",
                Date = "12/2023",
                FinalPrice = 99.99m,
                UserID = 10,
                IsAvailable = "true"
            };

            Assert.Equal(1, saleDTO.SaleID);
            Assert.Equal("12345", saleDTO.ZipCode);
            Assert.Equal(123, saleDTO.Cvv);
            Assert.Equal("1234-5678-9012-3456", saleDTO.CardNumber);
            Assert.Equal("12/2023", saleDTO.Date);
            Assert.Equal(99.99m, saleDTO.FinalPrice);
            Assert.Equal(10, saleDTO.UserID);
            Assert.Equal("true", saleDTO.IsAvailable);
        }

        [Fact]
        public void SaleDTOValidation_ShouldFailForInvalidData()
        {
            var invalidSaleDTO = new SaleDTO
            {
                SaleID = 1,
                ZipCode = "1asd2312345",
                Cvv = 123,
                CardNumber = "1234-5678-9012-3456",
                Date = "12/2023",
                FinalPrice = 99.99m,
                UserID = 10,
                IsAvailable = "true"
            };

            var validationResults = ValidateModel(invalidSaleDTO);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void SaleDTOValidation_ShouldPassForValidData()
        {
            var validSaleDTO = new SaleDTO
            {
                SaleID = 1,
                ZipCode = "12345",
                Cvv = 123,
                CardNumber = "1234-5678-9012-3456",
                Date = "12/2023",
                FinalPrice = 99.99m,
                UserID = 10,
                IsAvailable = "true"
            };

            var validationResults = ValidateModel(validSaleDTO);
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
