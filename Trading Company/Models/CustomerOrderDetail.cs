namespace Trading_Company.Models
{
    public class CustomerOrderDetail
    {
        public int CustomerOrderID { get; set; }
        public CustomerOrder CustomerOrder { get; set; }

        public int ItemID { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }

}
