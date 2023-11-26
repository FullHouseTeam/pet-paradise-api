using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Provider
    {
        [JsonIgnore]
        [Required]
        [MyDefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'ProviderID' property must be a number.")]
        public int ProviderID { get; set; }

        [Required]
        [MyDefaultValue("Ricardo Rodriguez Rojas")]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(200)]
        public string Name { get; set; }= string.Empty;

        [Required]
        [MyDefaultValue("Bolivian")]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(200)]
        public string Nationality { get; set; }= string.Empty;

        [Required]
        [MyDefaultValue("true")]
        [BooleanValue(ErrorMessage = "The 'IsAvailable' property must be a valid boolean.")]
        public bool IsAvailable { get; set; }
    }
}