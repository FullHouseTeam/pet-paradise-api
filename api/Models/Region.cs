using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace api.Models
{
    public class Region
    {
        [JsonIgnore]
        [Required]
        [MyDefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'RegionID' property must be an integer.")]
        public int RegionID { get; set; }

        [Required]
        [MyDefaultValue("13.5")]
        [DecimalValue(ErrorMessage = "The 'MunicipalTax' property must be a decimal number.")]
        [RangeValueDecimal(0.001, 100)]
        public decimal MunicipalTax { get; set; }

        [Required]
        [MyDefaultValue("16.5")]
        [DecimalValue(ErrorMessage = "The 'StatalTax' property must be a decimal number.")]
        [RangeValueDecimal(0.001, 100)]
        public decimal StatalTax { get; set; }
    }
}