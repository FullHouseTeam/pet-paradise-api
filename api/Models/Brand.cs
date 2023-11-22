using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Brand
    {
        //[JsonIgnore]
        [Required]
        [StringValue]
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