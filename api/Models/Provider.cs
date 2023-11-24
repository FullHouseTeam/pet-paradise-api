using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Provider
    {
        //[JsonIgnore]
        [Required]
        [DefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'ProviderID' property must be a number.")]
        public int ProviderID { get; set; }

        [Required]
        [DefaultValue("Ricardo Rodriguez Rojas")]
        [StringValue]
        [MaxLengthCharacters(200)]
        public string Name { get; set; }= string.Empty;

        [Required]
        [DefaultValue("Bolivian")]
        [StringValue]
        [MaxLengthCharacters(200)]
        public string Nationality { get; set; }= string.Empty;
    }
}