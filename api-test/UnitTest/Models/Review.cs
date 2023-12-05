using api.Models;
using Xunit;

namespace api_test.UnitTest.Models
{
    public class ReviewTest
    {
        [Fact]
        public void ReviewProperties_ShouldWorkCorrectly()
        {
            var review = new Review
            {
                ReviewID = 1,
                CustomerID = 2,
                ProductID = 3,
                ReviewMessage = "Test Review"
            };

            Assert.Equal(1, review.ReviewID);
            Assert.Equal(2, review.CustomerID);
            Assert.Equal(3, review.ProductID);
            Assert.Equal("Test Review", review.ReviewMessage);
        }
    }
}
