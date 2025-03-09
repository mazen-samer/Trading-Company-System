namespace Trading_Company.Models
{
    public class TransferOrderDetail
    {
        public int TransferOrderID { get; set; }
        public TransferOrder TransferOrder { get; set; }

        public int ItemID { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }

        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }

        public DateTime ProductionDate { get; set; }
        public int ExpirationPeriod { get; set; }
    }

}
