using System.ComponentModel.DataAnnotations;
using api.DTOs;

namespace api_test.UnitTest.DTOs
{
    public class ProductDTOTest
    {
        [Fact]
        public void ProductDTOProperties_ShouldWorkCorrectly()
        {
            var productDTO = new ProductDTO
            {
                ProductID = 1,
                Name = "Test Product",
                Price = 49.99m,
                Quantity = 100,
                Discount = 10,
                AnimalCategory = "Pets",
                Image = "https://example.com/image.png",
                Description = "Description of the product.",
                ProductType = "Type",
                BrandID = 1,
                ProviderID = 1,
                IsAvailable = true,
                HasTax = false
            };

            Assert.Equal(1, productDTO.ProductID);
            Assert.Equal("Test Product", productDTO.Name);
            Assert.Equal(49.99m, productDTO.Price);
            Assert.Equal(100, productDTO.Quantity);
            Assert.Equal(10, productDTO.Discount);
            Assert.Equal("Pets", productDTO.AnimalCategory);
            Assert.Equal("https://example.com/image.png", productDTO.Image);
            Assert.Equal("Description of the product.", productDTO.Description);
            Assert.Equal("Type", productDTO.ProductType);
            Assert.Equal(1, productDTO.BrandID);
            Assert.Equal(1, productDTO.ProviderID);
            Assert.True(productDTO.IsAvailable);
            Assert.False(productDTO.HasTax);
        }

        [Fact]
        public void ProductDTOValidation_ShouldFailForInvalidData()
        {
            var invalidProductDTO = new ProductDTO
            {
                ProductID = 1,
                Name = "Test Product",
                Price = 49.99m,
                Quantity = -40,
                Discount = -10,
                AnimalCategory = "Pets",
                Image = "https://example.com/image.png",
                Description = "Description of the product.",
                ProductType = "Type",
                BrandID = -51,
                ProviderID = -21,
                IsAvailable = true,
                HasTax = false
            };

            var validationResults = ValidateModel(invalidProductDTO);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void ProductDTOValidation_ShouldPassForValidData()
        {
            var validProductDTO = new ProductDTO
            {
                ProductID = 1,
                Name = "Test Product",
                Price = 49.99m,
                Quantity = 100,
                Discount = 10,
                AnimalCategory = "Pets",
                Image = "https://example.com/image.png",
                Description = "Description of the product",
                ProductType = "Type",
                BrandID = 1,
                ProviderID = 1,
                IsAvailable = true,
                HasTax = false
            };

            var validationResults = ValidateModel(validProductDTO);
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
