namespace Trading_Company.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }

        // Relationships
        public ICollection<WarehouseItem> WarehouseItems { get; set; }
        public ICollection<SupplyOrderDetail> SupplyOrderDetails { get; set; }
        public ICollection<WithdrawalOrderDetail> WithdrawalOrderDetails { get; set; }
        public ICollection<TransferOrderDetail> TransferOrderDetails { get; set; }
    }
}
