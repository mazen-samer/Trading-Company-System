namespace Trading_Company.Models
{
    public class CustomerOrder
    {
        public int WithdrawalOrderID { get; set; }
        public int WarehouseID { get; set; }
        public Warehouse Warehouse { get; set; }

        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }

        public DateTime OrderDate { get; set; }

        // Relationships
        public ICollection<CustomerOrderDetail> WithdrawalOrderDetails { get; set; }
    }

}
