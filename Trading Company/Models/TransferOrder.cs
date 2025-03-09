namespace Trading_Company.Models
{
    public class TransferOrder
    {
        public int TransferOrderID { get; set; }

        public int SourceWarehouseID { get; set; }
        public Warehouse SourceWarehouse { get; set; }

        public int DestinationWarehouseID { get; set; }
        public Warehouse DestinationWarehouse { get; set; }

        public DateTime OrderDate { get; set; }

        // Relationships
        public ICollection<TransferOrderDetail> TransferOrderDetails { get; set; }
    }

}
