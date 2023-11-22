using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Customer
    {
        //[JsonIgnore]
        [Required]
        [DefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'CustomerID' property must be an integer.")]
        public int CustomerID { get; set; }

        [Required]
        [DefaultValue("luchoespinoza@gmail.com")]
        [EmailAddress(ErrorMessage = "The email format is incorrect.")]
        [StringValue]
        [MaxLengthCharacters(40)]
        public string Email { get; set; }= string.Empty;

        [Required]
        [DefaultValue("Lucho")]
        [StringValue]
        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [Required]
        [DefaultValue("AAglobal12")]
        [StringValue]
        [MaxLengthCharacters(40)]
        public string Password { get; set; }= string.Empty;

        [Required]
        [DefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'RegionID' property must be an integer.")]

        public int RegionID { get; set; }

        [Required]
        [DefaultValue("9628512")]
        [IntegerValue(ErrorMessage = "The 'Nit' property must be an integer.")]
        [RangeValueInt(6000000, 9999999)]
        public int Nit { get; set; }
    }
}