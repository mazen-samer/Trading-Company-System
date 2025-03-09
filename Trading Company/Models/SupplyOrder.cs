namespace Trading_Company.Models
{
    public class SupplyOrder
    {
        public int SupplyOrderID { get; set; }
        public int WarehouseID { get; set; }
        public Warehouse Warehouse { get; set; }

        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }

        public DateTime OrderDate { get; set; }

        // Relationships
        public ICollection<SupplyOrderDetail> SupplyOrderDetails { get; set; }
    }

}
