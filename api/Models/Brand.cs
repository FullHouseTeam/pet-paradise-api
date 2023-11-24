using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Brand
    {
        //[JsonIgnore]
        [Required]
        [DefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'CustomerID' property must be an integer.")]
        public int BrandID { get; set; }

        [Required]
        [StringValue]
        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [Required]
        [StringValue]
        [MaxLengthCharacters(300)]
        public string Logo { get; set; }= string.Empty;
    }
}