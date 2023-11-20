using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Region
    {
        //[JsonIgnore]
        public int RegionID { get; set; }

        [DecimalValue(ErrorMessage = "The 'MunicipalTax' property must be a decimal number.")]
        [RangeValueDecimal(0.001, 100)]
        public decimal MunicipalTax { get; set; }

        [DecimalValue(ErrorMessage = "The 'StatalTax' property must be a decimal number.")]
        [RangeValueDecimal(0.001, 100)]
        public decimal StatalTax { get; set; }
    }
}