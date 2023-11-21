namespace api.Models
{
    public class Purchase
    {
        //[JsonIgnore]
        public int PurchaseID { get; set; }

        [DecimalValue(ErrorMessage = "The 'TotalPrice' property must be a decimal number.")]
        [RangeValueDecimal(0.001, 500000)]
        public decimal TotalPrice { get; set; }

        public DateTime ReportDate { get; set; }

        [DecimalValue(ErrorMessage = "The 'ObtainedTaxes' property must be a decimal number.")]
        [RangeValueDecimal(0.001, 100)]
        public decimal ObtainedTaxes { get; set; }

        [DecimalValue(ErrorMessage = "The 'ApplicationTax' property must be a decimal number.")]
        [RangeValueDecimal(0.001, 100)]
        public decimal ApplicationTax { get; set; }

        [DecimalValue(ErrorMessage = "The 'DeliveryTime' property must be a decimal number.")]
        [RangeValueDecimal(0.001, 20)]
        public decimal DeliveryTime { get; set; }

        public int ProductID { get; set; }

        public int UserID { get; set; }
    }
}