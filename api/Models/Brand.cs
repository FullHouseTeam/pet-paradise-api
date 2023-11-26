using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Brand
    {
        [JsonIgnore]
        [Required]
        [DefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'CustomerID' property must be an integer.")]
        public int BrandID { get; set; }

        [Required]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [Required]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(300)]
        public string Logo { get; set; }= string.Empty;
    }
}