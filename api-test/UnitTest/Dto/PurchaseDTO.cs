using System.ComponentModel.DataAnnotations;
using api.DTOs;
using Xunit;

namespace api_test.UnitTest.DTOs
{
    public class PurchaseDTOTest
    {
        [Fact]
        public void PurchaseDTOProperties_ShouldWorkCorrectly()
        {
            var purchaseDTO = new PurchaseDTO
            {
                PurchaseID = 1,
                TotalPrice = 50.75m,
                ObtainedTaxes = 5.25m,
                DeliveryTime = 2.5m,
                LocalQuantity = 3,
                ProductID = 10,
                UserID = 20,
                IsAvailable = true
            };

            Assert.Equal(1, purchaseDTO.PurchaseID);
            Assert.Equal(50.75m, purchaseDTO.TotalPrice);
            Assert.Equal(5.25m, purchaseDTO.ObtainedTaxes);
            Assert.Equal(2.5m, purchaseDTO.DeliveryTime);
            Assert.Equal(3, purchaseDTO.LocalQuantity);
            Assert.Equal(10, purchaseDTO.ProductID);
            Assert.Equal(20, purchaseDTO.UserID);
            Assert.True(purchaseDTO.IsAvailable);
        }

        [Fact]
        public void PurchaseDTOValidation_ShouldFailForInvalidData()
        {
            var invalidPurchaseDTO = new PurchaseDTO
            {
                PurchaseID = 1,
                TotalPrice = 50.75m,
                ObtainedTaxes = 155.25m,
                DeliveryTime = 2.5m,
                LocalQuantity = 3,
                ProductID = 10,
                UserID = 20,
                IsAvailable = true
            };

            var validationResults = ValidateModel(invalidPurchaseDTO);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void PurchaseDTOValidation_ShouldPassForValidData()
        {
            var validPurchaseDTO = new PurchaseDTO
            {
                PurchaseID = 1,
                TotalPrice = 50.75m,
                ObtainedTaxes = 5.25m,
                DeliveryTime = 2.5m,
                LocalQuantity = 3,
                ProductID = 10,
                UserID = 20,
                IsAvailable = true
            };

            var validationResults = ValidateModel(validPurchaseDTO);
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
