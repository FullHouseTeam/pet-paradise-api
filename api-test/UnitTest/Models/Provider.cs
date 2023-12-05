using api.Models;
using Xunit;

namespace api_test.UnitTest.Models
{
    public class ProviderTest
    {
        [Fact]
        public void ProviderProperties_ShouldWorkCorrectly()
        {
            var provider = new Provider
            {
                ProviderID = 1,
                Name = "Test Provider",
                Nationality = "Country A",
                IsAvailable = "true"
            };

            Assert.Equal(1, provider.ProviderID);
            Assert.Equal("Test Provider", provider.Name);
            Assert.Equal("Country A", provider.Nationality);
            Assert.Equal("true", provider.IsAvailable);
        }
    }
}
