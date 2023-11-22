namespace api.DTOs
{
    public class PurchaseDTO
    {
        public int PurchaseID { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime ReportDate { get; set; }

        public decimal ObtainedTaxes { get; set; }

        public decimal ApplicationTax { get; set; }

        public decimal DeliveryTime { get; set; }

        public int ProductID { get; set; }

        public int UserID { get; set; }
    }
}