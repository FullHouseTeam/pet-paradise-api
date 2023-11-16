
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Product
    {
        //[JsonIgnore]
        public int ProductID { get; set; }

        [StringValue]
        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [DecimalPrecision(2, ErrorMessage = "The 'Price' property must have up to 2 decimal places.")]
        [DecimalValue(ErrorMessage = "The 'Price' property must be a decimal number.")]
        [RangeValueDecimal(0.0001, 500000)]
        public decimal Price { get; set; }

        [IntValue(ErrorMessage = "The 'Quantity' property must be an integer.")]
        [RangeValueInt(1, 250000)]
        public int Quantity { get; set; }

        [IntValue(ErrorMessage = "The 'Discount' property must be an integer.")]
        [RangeValueInt(1, 60)]
        public int Discount { get; set; }

        [StringValue]
        [MaxLengthCharacters(40)]
        public string AnimalCategory { get; set; }= string.Empty;

        [StringValue]
        [MaxLengthCharacters(300)]
        public string Image { get; set; }= string.Empty;

        [StringValue]
        [MaxLengthCharacters(1000)]
        public string Description { get; set; }= string.Empty;

        [StringValue]
        [MaxLengthCharacters(40)]
        public string ProductType { get; set; }= string.Empty;

        [IntValue(ErrorMessage = "The 'Discount' property must be an integer.")]
        public int BrandID { get; set; }

        [IntValue(ErrorMessage = "The 'ProviderID' property must be an integer.")]
        public int ProviderID { get; set; }

        [IntValue(ErrorMessage = "The 'HasTax' property must be an integer.")]
        [RangeValueInt(1, 60)]
        public int HasTax { get; set; }
    }
}
