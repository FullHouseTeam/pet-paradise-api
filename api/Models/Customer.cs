using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Customer
    {
        [JsonIgnore]
        [Required]
        [MyDefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'CustomerID' property must be an integer.")]
        public int CustomerID { get; set; }

        [Required]
        [MyDefaultValue("luchoespinoza@gmail.com")]
        [StringOnly]
        [EmailAddress(ErrorMessage = "The email format is incorrect.")]
        [StringValue]
        [MaxLengthCharacters(40)]
        public string Email { get; set; }= string.Empty;

        [Required]
        [MyDefaultValue("Lucho")]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [Required]
        [MyDefaultValue("AAglobal12")]
        [StringValue]
        [StringOnly]
        [MaxLengthCharacters(40)]
        public string Password { get; set; }= string.Empty;

        [Required]
        [MyDefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'RegionID' property must be an integer.")]

        public int RegionID { get; set; }

        [Required]
        [MyDefaultValue("9628512")]
        [IntegerValue(ErrorMessage = "The 'Nit' property must be an integer.")]
        [RangeValueInt(6000000, 9999999)]
        public int Nit { get; set; }
    }
}