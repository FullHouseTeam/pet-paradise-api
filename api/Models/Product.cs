
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Product
    {
        [JsonIgnore]
        public int ProductID { get; set; }

        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [DecimalValue(ErrorMessage = "La propiedad 'Price' debe ser un número decimal.")]
        [RangeValueDecimal(1, 500000)]
        public decimal Price { get; set; }

        [IntValue(ErrorMessage = "La propiedad 'Quantity' debe ser un número entero.")]
        [RangeValueInt(1, 250000)]
        public int Quantity { get; set; }

        [IntValue(ErrorMessage = "La propiedad 'Discount' debe ser un número entero.")]
        [RangeValueInt(1, 60)]
        public int Discount { get; set; }

        [MaxLengthCharacters(40)]
        public string AnimalCategory { get; set; }= string.Empty;

        [MaxLengthCharacters(300)]
        public string Image { get; set; }= string.Empty;

        [MaxLengthCharacters(1000)]
        public string Description { get; set; }= string.Empty;

        [MaxLengthCharacters(40)]
        public string ProductType { get; set; }= string.Empty;

        [IntValue(ErrorMessage = "La propiedad 'BrandID' debe ser un número entero.")]
        public int BrandID { get; set; }

        [IntValue(ErrorMessage = "La propiedad 'ProviderID' debe ser un número entero.")]
        public int ProviderID { get; set; }

        [IntValue(ErrorMessage = "La propiedad 'HasTax' debe ser un número entero.")]
        [RangeValueInt(1, 60)]
        public int HasTax { get; set; }
    }
}
