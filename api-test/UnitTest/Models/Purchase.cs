using api.Models;
using Xunit;

namespace api_test.UnitTest.Models
{
    public class PurchaseTest
    {
        [Fact]
        public void PurchaseProperties_ShouldWorkCorrectly()
        {
            var purchase = new Purchase
            {
                PurchaseID = 1,
                TotalPrice = 100.50m,
                ReportDate = "2023-12-01",
                ObtainedTaxes = 10.25m,
                ApplicationTax = 5.75m,
                DeliveryTime = 3.5m,
                LocalQuantity = 2,
                ProductID = 3,
                UserID = 4,
                IsAvailable = "true"
            };

            Assert.Equal(1, purchase.PurchaseID);
            Assert.Equal(100.50m, purchase.TotalPrice);
            Assert.Equal("2023-12-01", purchase.ReportDate);
            Assert.Equal(10.25m, purchase.ObtainedTaxes);
            Assert.Equal(5.75m, purchase.ApplicationTax);
            Assert.Equal(3.5m, purchase.DeliveryTime);
            Assert.Equal(2, purchase.LocalQuantity);
            Assert.Equal(3, purchase.ProductID);
            Assert.Equal(4, purchase.UserID);
            Assert.Equal("true", purchase.IsAvailable);
        }
    }
}
