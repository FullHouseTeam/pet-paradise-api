using api.Models.Transactions;
using Xunit;

namespace api_test.UnitTest.Models.Transactions
{
    public class SaleTest
    {
        [Fact]
        public void SaleProperties_ShouldWorkCorrectly()
        {
            var sale = new Sale
            {
                SaleID = 1,
                ZipCode = "12345",
                Cvv = 123,
                CardNumber = "1234-5678-9012-3456",
                Date = "2023-12-31",
                FinalPrice = 100.50m,
                UserID = 2,
                IsAvailable = "true"
            };

            Assert.Equal(1, sale.SaleID);
            Assert.Equal("12345", sale.ZipCode);
            Assert.Equal(123, sale.Cvv);
            Assert.Equal("1234-5678-9012-3456", sale.CardNumber);
            Assert.Equal("2023-12-31", sale.Date);
            Assert.Equal(100.50m, sale.FinalPrice);
            Assert.Equal(2, sale.UserID);
            Assert.Equal("true", sale.IsAvailable);
        }
    }
}
