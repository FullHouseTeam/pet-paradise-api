using api;
using api.Utilities;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace UnitTests
{
    public class UnitClass
    {
        [Fact]
        public void ValidationStringTest()
        {
            var errorUtilities = ErrorUtilities.ValidateString("1");
            string messageIdPositive = "This field needs (1) to be a String.";

            Assert.Equal(errorUtilities, messageIdPositive);
        }

        [Fact]
        public void ValidationIntTest()
        {
            var errorUtilities = ErrorUtilities.ValidateInt("3");
            string messageIdPositive = "This field needs (3) to be an Integer.";

            Assert.Equal(errorUtilities, messageIdPositive);
        }

        [Fact]
        public void MaxLengthErrorMessageTest()
        {
            var errorUtilities = ErrorUtilities.MaxLengthErrorMessage("Name", 40);
            string messageIdPositive = "The (Name) field cannot exceed (40) characters.";

            Assert.Equal(errorUtilities, messageIdPositive);
        }

        [Fact]
        public void RangeValueErrorMessageIntTest()
        {
            var errorUtilities = ErrorUtilities.RangeValueErrorMessageInt(100, 999);
            string messageIdPositive = "The number must be greater than or equal to (100) and less than (999).";

            Assert.Equal(errorUtilities, messageIdPositive);
        }

        [Fact]
        public void RangeValueErrorMessageDecimalTest()
        {
            var errorUtilities = ErrorUtilities.RangeValueErrorMessageDecimal(2.5, 9.5);
            string messageIdPositive = "The number must be greater than or equal to (2.5) and less than (9.5).";

            Assert.Equal(errorUtilities, messageIdPositive);
        }

        [Fact]
        public void PositiveNumberTest()
        {
            var errorUtilities = ErrorUtilities.PositiveNumber("Name");
            string messageIdPositive = "This field (Name) must be a positive number.";

            Assert.Equal(errorUtilities, messageIdPositive);
        }

        [Fact]
        public void IsRequiredTest()
        {
            var errorUtilities = ErrorUtilities.IsRequired("Name");
            string messageIdPositive = "This field (Name) is required.";

            Assert.Equal(errorUtilities, messageIdPositive);
        }

        [Fact]
        public void NoSpecialCharacters()
        {
            var errorUtilities = ErrorUtilities.NoSpecialCharacters("Name");
            string messageIdPositive = "The (Name) field must not contain special characters";

            Assert.Equal(errorUtilities, messageIdPositive);
        }

        [Fact]
        public void NoSpecialNumbers()
        {
            var errorUtilities = ErrorUtilities.NoSpecialNumbers("Name");
            string messageIdPositive = "The (Name) field must not contain numbers";

            Assert.Equal(errorUtilities, messageIdPositive);
        }

        [Fact]
        public void FieldNotFoundTest()
        {
            var errorUtilities = ErrorUtilities.FieldNotFound("Name", 300);
            var notFound = new NotFoundObjectResult(new { message = $"The Name with ID = 300 doesn't exist." });

            string errorUtilitiesString = errorUtilities.Value?.ToString() ?? "Value is null";
            string notFoundString = notFound.Value?.ToString() ?? "Value is null";

            Assert.Equal(notFoundString, errorUtilitiesString);
        }

        [Fact]
        public void IdPositiveTest()
        {
            var errorUtilities = ErrorUtilities.IdPositive(-5);
            var notFound = new NotFoundObjectResult(new { message = $"ID = -5 must be a positive value greater than 0." });

            string errorUtilitiesString = errorUtilities.Value?.ToString() ?? "Value is null";
            string notFoundString = notFound.Value?.ToString() ?? "Value is null";

            Assert.Equal(notFoundString, errorUtilitiesString);
        }

        [Fact]
        public void UniqueNameTest()
        {
            var errorUtilities = ErrorUtilities.UniqueName("Julian");
            var notFound = new NotFoundObjectResult(new { message = $"The Julian name already exists. Provide a unique name." });

            string errorUtilitiesString = errorUtilities.Value?.ToString() ?? "Value is null";
            string notFoundString = notFound.Value?.ToString() ?? "Value is null";

            Assert.Equal(notFoundString, errorUtilitiesString); 
        }

        [Fact]
        public void EmailNameTest()
        {
            var errorUtilities = ErrorUtilities.EmailName("manuel@gmail.com");
            var notFound = new NotFoundObjectResult(new { message = $"The manuel@gmail.com email already exists. Provide a unique email." });
            
            string errorUtilitiesString = errorUtilities.Value?.ToString() ?? "Value is null";
            string notFoundString = notFound.Value?.ToString() ?? "Value is null";

            Assert.Equal(errorUtilitiesString, notFoundString);
        }
    }
}
