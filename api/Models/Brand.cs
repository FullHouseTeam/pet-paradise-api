using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models
{   
    public class Brand
    {
        [JsonIgnore]
        [Required]
        [IntegerValue(ErrorMessage = "The 'BrandID' property must be an integer.")]
        public int BrandID { get; set; }

        [Required]
        [StringValue]
        [StringOnly]
        [DefaultValue("Ricocan")]
        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [Required]
        [StringValue]
        [StringOnly]
        [HttpsUrl(ErrorMessage = "The 'Logo' URL must start with 'https:'.")]
        [DefaultValue("https://www.purina.es/sites/default/files/styles/ttt_image_510/public/2022-02/IMG_PurinaProductsES_540x405_0.jpg?itok=HOQXAI5C")]
        [MaxLengthCharacters(300)]
        public string Logo { get; set; }= string.Empty;

        [Required]
        [DefaultValue("true")]
        [BooleanValue(ErrorMessage = "The 'IsAvailable' property must be a valid boolean.")]
        public bool IsAvailable { get; set; 
        }
    }
}
