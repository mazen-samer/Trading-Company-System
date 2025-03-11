namespace Trading_Company.Models
{
    public class CustomerOrder
    {
        public int CustomerOrderID { get; set; }
        public int WarehouseID { get; set; }
        public Warehouse Warehouse { get; set; }

        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }

        public DateTime OrderDate { get; set; }

        // Relationships
        public ICollection<CustomerOrderDetail> CustomerOrderDetails { get; set; }
    }

}
