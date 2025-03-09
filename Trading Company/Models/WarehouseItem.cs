namespace Trading_Company.Models
{
    public class WarehouseItem
    {
        public int WarehouseID { get; set; }
        public Warehouse Warehouse { get; set; }

        public int ItemID { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }

        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
