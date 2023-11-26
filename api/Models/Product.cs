
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace api.Models
{
    public class Product
    {
        [JsonIgnore]
        [Required]
        [MyDefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'ProductID' property must be an integer.")]
        public int ProductID { get; set; }

        [Required]
        [MyDefaultValue("Dog Chow")]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [Required]
        [MyDefaultValue("31.5")]
        [DecimalPrecision(2, ErrorMessage = "The 'Price' property must have up to 2 decimal places.")]
        [DecimalValue(ErrorMessage = "The 'Price' property must be a decimal number.")]
        [RangeValueDecimal(0.0001, 500000)]
        public decimal Price { get; set; }

        [Required]
        [MyDefaultValue("150")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "El campo debe ser un número entero.")]
        [IntegerValue(ErrorMessage = "The 'Quantity' property must be an integer.")]
        [RangeValueInt(1, 250000)]
        public int Quantity { get; set; }

        [Required]
        [MyDefaultValue("15")]
        [IntegerValue(ErrorMessage = "The 'Discount' property must be an integer.")]
        [RangeValueInt(1, 60)]
        public int Discount { get; set; }

        [Required]
        [MyDefaultValue("Dog")]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(40)]
        public string AnimalCategory { get; set; }= string.Empty;

        [Required]
        [MyDefaultValue("https://www.agrocampo.com.co/media/catalog/product/cache/d51e0dc10c379a6229d70d752fc46d83/1/1/111101688_ed-min.jpg")]
        [HttpsUrl(ErrorMessage = "The 'Image' URL must start with 'https:'.")]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(300)]
        public string Image { get; set; }= string.Empty;

        [Required]
        [MyDefaultValue("This is a very economical dog food.")]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(1000)]
        public string Description { get; set; }= string.Empty;

        [Required]
        [MyDefaultValue("Food")]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(40)]
        public string ProductType { get; set; }= string.Empty;

        [Required]
        [MyDefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'BrandID' property must be an integer.")]
        public int BrandID { get; set; }

        [Required]
        [MyDefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'ProviderID' property must be an integer.")]
        public int ProviderID { get; set; }

        [Required]
        [MyDefaultValue("true")]
        [BooleanValue(ErrorMessage = "The 'IsAvailable' property must be a valid boolean.")]
        public bool IsAvailable { get; set; }

        [Required]
        [MyDefaultValue("false")]
        [BooleanValue(ErrorMessage = "The 'HasTax' property must be a valid boolean.")]
        public bool HasTax { get; set; }      
    }
}
