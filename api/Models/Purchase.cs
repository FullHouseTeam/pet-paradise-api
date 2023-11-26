using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Purchase
    {
        [JsonIgnore]
        [Required]
        [IntegerValue(ErrorMessage = "The 'PurchaseID' property must be an integer.")]
        public int PurchaseID { get; set; }

        [Required]
        [DefaultValue("15.5")]
        [DecimalPrecision(2, ErrorMessage = "The 'TotalPrice' property must have up to 2 decimal places.")]
        [DecimalValue(ErrorMessage = "The 'TotalPrice' property must be a decimal number.")]
        [RangeValueDecimal(0.01, 500000)]
        public decimal TotalPrice { get; set; }

        [Required]
        [DefaultValue("05/05/2023")]
        public DateTime ReportDate { get; set; }

        [Required]
        [DefaultValue("13.5")]
        [DecimalPrecision(2, ErrorMessage = "The 'ObtainedTaxes' property must have up to 2 decimal places.")]
        [DecimalValue(ErrorMessage = "The 'ObtainedTaxes' property must be a decimal number.")]
        [RangeValueDecimal(0.01, 100)]
        public decimal ObtainedTaxes { get; set; }

        [Required]
        [DefaultValue("4.5")]
        [DecimalPrecision(2, ErrorMessage = "The 'ApplicationTax' property must have up to 2 decimal places.")]
        [DecimalValue(ErrorMessage = "The 'ApplicationTax' property must be a decimal number.")]
        [RangeValueDecimal(0.01, 100)]
        public decimal ApplicationTax { get; set; }

        [Required]
        [DefaultValue("4.0")]
        [DecimalPrecision(2, ErrorMessage = "The 'DeliveryTime' property must have up to 2 decimal places.")]
        [DecimalValue(ErrorMessage = "The 'DeliveryTime' property must be a decimal number.")]
        [RangeValueDecimal(0.01, 20)]
        public decimal DeliveryTime { get; set; }

        [Required]
        [DefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'ProductID' property must be an integer.")]
        public int ProductID { get; set; }

        [Required]
        [DefaultValue("1")]
        [IntegerValue(ErrorMessage = "The 'UserID' property must be an integer.")]
        public int UserID { get; set; }
    }
}
