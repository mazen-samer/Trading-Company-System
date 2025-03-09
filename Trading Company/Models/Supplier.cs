namespace Trading_Company.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        // Relationships
        public ICollection<SupplyOrder> SupplyOrders { get; set; }
        public ICollection<TransferOrderDetail> TransferOrderDetails { get; set; }
    }

}
