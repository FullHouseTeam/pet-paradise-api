
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class Product
    {
        //[JsonIgnore]
        [DefaultValue("1")]
        public int ProductID { get; set; }

        [Required]
        [StringOnly(ErrorMessage = "El campo 'name' debe ser una cadena (string).")]
        [DefaultValue("Dog Chow")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
        [DataType(DataType.Text, ErrorMessage = "El campo debe ser de tipo texto.")]
        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [Required]
        [DefaultValue("31.5")]
        [DecimalPrecision(2, ErrorMessage = "The 'Price' property must have up to 2 decimal places.")]
        [DecimalValue(ErrorMessage = "The 'Price' property must be a decimal number.")]
        [RangeValueDecimal(0.0001, 500000)]
        public decimal Price { get; set; }

        [Required]
        [DefaultValue("150")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "El campo debe ser un número entero.")]
        [IntegerValue(ErrorMessage = "The 'Quantity' property must be an integer.")]
        [RangeValueInt(1, 250000)]
        public int Quantity { get; set; }

        [Required]
        [DefaultValue("15")]
        [IntegerValue(ErrorMessage = "The 'Discount' property must be an integer.")]
        [RangeValueInt(1, 60)]
        public int Discount { get; set; }

        [Required]
        [DefaultValue("Dog")]
        [MaxLengthCharacters(40)]
        public string AnimalCategory { get; set; }= string.Empty;

        [Required]
        [DefaultValue("-- Link URL --")]
        [MaxLengthCharacters(300)]
        public string Image { get; set; }= string.Empty;

        [Required]
        [DefaultValue("This is a very economical dog food.")]
        [MaxLengthCharacters(1000)]
        public string Description { get; set; }= string.Empty;

        [Required]
        [DefaultValue("Food")]
        [MaxLengthCharacters(40)]
        public string ProductType { get; set; }= string.Empty;

        [Required]
        [DefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'Discount' property must be an integer.")]
        public int BrandID { get; set; }

        [Required]
        [DefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'ProviderID' property must be an integer.")]
        public int ProviderID { get; set; }

        [Required]
        [DefaultValue("15")]
        public bool HasTax { get; set; }
    }
}
