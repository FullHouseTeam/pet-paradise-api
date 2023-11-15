using Microsoft.AspNetCore.Mvc;

namespace api.Utilities
{
    public static class ErrorUtilities
    {
        public static NotFoundObjectResult ProductNotFound(int id)
        {
            return new NotFoundObjectResult(new { message = $"The product with ID = {id} doesn't exist." });
        }

        public static string MaxLengthErrorMessage(int quantity) => $"El texto debe ser menor a ({quantity}) caracteres.";

        public static string RangeValueErrorMessageInt(int range1, int range2) => $"El numero debe ser mayor o igual a ({range1}) y menor a ({range2}).";

        public static string RangeValueErrorMessageDecimal(double range1, double range2) => $"El número debe ser mayor o igual a ({range1}) y menor a ({range2}).";
  }
}
