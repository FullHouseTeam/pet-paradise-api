using System.Text.Json.Serialization;

namespace api.DTOs
{
    public class RegionDTO
    {
        [JsonIgnore]
        public int RegionID { get; set; }

        [Required("MunicipalTax")]
        [DecimalValue(ErrorMessage = "The 'MunicipalTax' property must be a decimal number.")]
        [RangeValueDecimal(0.01, 100)]
        public decimal MunicipalTax { get; set; }

        [Required("StatalTax")]
        [DecimalValue(ErrorMessage = "The 'StatalTax' property must be a decimal number.")]
        [RangeValueDecimal(0.01, 100)]
        public decimal StatalTax { get; set; }
    }
}