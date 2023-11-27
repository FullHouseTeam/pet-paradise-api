using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Region
    {
        [JsonIgnore]
        [Required]
        [IntegerValue(ErrorMessage = "The 'RegionID' property must be an integer.")]
        public int RegionID { get; set; }

        [Required]
        //[DefaultValue("13.5")]
        [DecimalValue(ErrorMessage = "The 'MunicipalTax' property must be a decimal number.")]
        [RangeValueDecimal(0.01, 100)]
        public decimal MunicipalTax { get; set; }

        [Required]
        //[DefaultValue("16.5")]
        [DecimalValue(ErrorMessage = "The 'StatalTax' property must be a decimal number.")]
        [RangeValueDecimal(0.01, 100)]
        public decimal StatalTax { get; set; }
    }
}
