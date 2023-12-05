using api.Models;
using Xunit;

namespace api_test.UnitTest.Models
{
    public class RegionTest
    {
        [Fact]
        public void RegionProperties_ShouldWorkCorrectly()
        {
            var region = new Region
            {
                RegionID = 1,
                Name = "Test Region",
                MunicipalTax = 8.5m,
                StatalTax = 5.75m
            };

            Assert.Equal(1, region.RegionID);
            Assert.Equal("Test Region", region.Name);
            Assert.Equal(8.5m, region.MunicipalTax);
            Assert.Equal(5.75m, region.StatalTax);
        }
    }
}
