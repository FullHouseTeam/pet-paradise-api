using api.Models;

namespace api_test.UnitTest.Models
{
    public class BrandTest
    {
        [Fact]
        public void BrandProperties_ShouldWorkCorrectly()
        {
        var brand = new Brand
        {
            BrandID = 1,
            Name = "Test Brand",
            Logo = "brand-logo.png",
            IsAvailable = "true"
        };
        Assert.Equal(1, brand.BrandID);
        Assert.Equal("Test Brand", brand.Name);
        Assert.Equal("brand-logo.png", brand.Logo);
        Assert.Equal("true", brand.IsAvailable);
        }
    }
}
