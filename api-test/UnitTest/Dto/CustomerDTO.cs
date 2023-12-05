using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using api.DTOs;
using Xunit;

namespace api_test.UnitTest.DTOs
{
    public class CustomerDTOTest
    {
        [Fact]
        public void CustomerDTOProperties_ShouldWorkCorrectly()
        {
            var customerDTO = new CustomerDTO
            {
                CustomerID = 1,
                Email = "test@example.com",
                Name = "Test Customer",
                Password = "securePassword",
                RegionID = 123,
                Nit = 7890123,
                IsAvailable = true
            };

            Assert.Equal(1, customerDTO.CustomerID);
            Assert.Equal("test@example.com", customerDTO.Email);
            Assert.Equal("Test Customer", customerDTO.Name);
            Assert.Equal("securePassword", customerDTO.Password);
            Assert.Equal(123, customerDTO.RegionID);
            Assert.Equal(7890123, customerDTO.Nit);
            Assert.True(customerDTO.IsAvailable);
        }

        [Fact]
        public void CustomerDTOValidation_ShouldFailForInvalidData()
        {
            var invalidCustomerDTO = new CustomerDTO
            {
                CustomerID = 1,
                Email = "user@gmail.com",
                Name = "Invalid Customer 123",
                Password = "G3asdaic",
                RegionID = -1,
                Nit = 123,
                IsAvailable = false
            };

            var validationResults = ValidateModel(invalidCustomerDTO);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void CustomerDTOValidation_ShouldPassForValidData()
        {
            var validCustomerDTO = new CustomerDTO
            {
                CustomerID = 1,
                Email = "user@gmail.com",
                Name = "Valid",
                Password = "G3asdaic",
                RegionID = 4,
                Nit = 9876543,
                IsAvailable = true
            };

            var validationResults = ValidateModel(validCustomerDTO);
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
