using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Provider
    {
        [JsonIgnore]
        [Required]
        [IntegerValue(ErrorMessage = "The 'ProviderID' property must be a number.")]
        public int ProviderID { get; set; }

        [Required]
        //[DefaultValue("Ricardo Rodriguez Rojas")]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(200)]
        public string Name { get; set; }= string.Empty;

        [Required]
        //[DefaultValue("Bolivian")]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(200)]
        public string Nationality { get; set; }= string.Empty;

        [Required]
        //[DefaultValue("true")]
        public string IsAvailable { get; set; }= string.Empty;
    }
}
