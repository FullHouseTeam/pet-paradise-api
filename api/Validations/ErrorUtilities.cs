using Microsoft.AspNetCore.Mvc;

namespace api.Utilities
{
    public static class ErrorUtilities
    {
        public static NotFoundObjectResult ProductNotFound(int id)
        {
            return new NotFoundObjectResult(new { message = $"The product with ID = {id} doesn't exist." });
        }
        
        public static NotFoundObjectResult BrandNotFound(int id)
        {
            return new NotFoundObjectResult(new { message = $"The brand with ID = {id} doesn't exist." });
        }

        public static NotFoundObjectResult IdPositive(int id)
        {
            return new NotFoundObjectResult(new { message = $"ID = {id} must be a positive value greater than 0." });
        }
        
        public static string MaxLengthErrorMessage(int quantity) => $"The text must be less than ({quantity}) characters.";

        public static string RangeValueErrorMessageInt(int range1, int range2) => $"The number must be greater than or equal to ({range1}) and less than ({range2}).";

        public static string RangeValueErrorMessageDecimal(double range1, double range2) => $"The number must be greater than or equal to ({range1}) and less than ({range2}).";
  }
}