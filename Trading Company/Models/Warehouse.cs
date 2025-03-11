namespace Trading_Company.Models
{
    public class Warehouse
    {
        public int WarehouseID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ResponsiblePerson { get; set; }

        // Relationships
        public ICollection<WarehouseItem> WarehouseItems { get; set; }
        public ICollection<SupplyOrder> SupplyOrders { get; set; }
        public ICollection<CustomerOrder> CustomerOrders { get; set; }
        public ICollection<TransferOrder> SourceTransfers { get; set; }
        public ICollection<TransferOrder> DestinationTransfers { get; set; }
    }

}
