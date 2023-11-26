using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Review
    {
        [JsonIgnore]
        [Required]
        [IntegerValue(ErrorMessage = "The 'ReviewID' property must be an integer.")]
        public int ReviewID { get; set; }

        [Required]
        [DefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'CustomerID' property must be an integer.")]
        public int CustomerID { get; set; }

        [Required]
        [DefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'ProductID' property must be an integer.")]
        public int ProductID { get; set; }

        [Required]
        [DefaultValue("This is a good product")]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(200)]
        public string ReviewMessage { get; set; }= string.Empty;
    }
}
