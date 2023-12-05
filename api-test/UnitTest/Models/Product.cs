using api.Models;
using Xunit;

namespace api_test.UnitTest.Models
{
    public class ProductTest
    {
        [Fact]
        public void ProductProperties_ShouldWorkCorrectly()
        {
            var product = new Product
            {
                ProductID = 1,
                Name = "Test Product",
                Price = 19.99m,
                Quantity = 10,
                Discount = 5,
                AnimalCategory = "Pets",
                Image = "product-image.jpg",
                Description = "This is a test product",
                ProductType = "Type A",
                BrandID = 2,
                ProviderID = 3,
                IsAvailable = "true",
                HasTax = "false"
            };

            Assert.Equal(1, product.ProductID);
            Assert.Equal("Test Product", product.Name);
            Assert.Equal(19.99m, product.Price);
            Assert.Equal(10, product.Quantity);
            Assert.Equal(5, product.Discount);
            Assert.Equal("Pets", product.AnimalCategory);
            Assert.Equal("product-image.jpg", product.Image);
            Assert.Equal("This is a test product", product.Description);
            Assert.Equal("Type A", product.ProductType);
            Assert.Equal(2, product.BrandID);
            Assert.Equal(3, product.ProviderID);
            Assert.Equal("true", product.IsAvailable);
            Assert.Equal("false", product.HasTax);
        }
    }
}
