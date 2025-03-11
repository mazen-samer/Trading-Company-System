namespace Trading_Company.Models
{
    public class SupplyOrderDetail
    {
        public int SupplyOrderID { get; set; }
        public SupplyOrder SupplyOrder { get; set; }

        public int ItemID { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

}
