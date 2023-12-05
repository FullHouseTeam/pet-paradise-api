using api.Models;
using Xunit;

namespace api_test.UnitTest.Models
{
    public class CustomerTest
    {
        [Fact]
        public void CustomerProperties_ShouldWorkCorrectly()
        {
            var customer = new Customer
            {
                CustomerID = 1,
                Email = "test@example.com",
                Name = "Test Customer",
                Password = "password123",
                RegionID = 2,
                Nit = 123456789,
                IsAvailable = "true"
            };

            Assert.Equal(1, customer.CustomerID);
            Assert.Equal("test@example.com", customer.Email);
            Assert.Equal("Test Customer", customer.Name);
            Assert.Equal("password123", customer.Password);
            Assert.Equal(2, customer.RegionID);
            Assert.Equal(123456789, customer.Nit);
            Assert.Equal("true", customer.IsAvailable);
        }
    }
}
