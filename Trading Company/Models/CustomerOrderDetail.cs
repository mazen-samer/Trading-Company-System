namespace Trading_Company.Models
{
    public class CustomerOrderDetail
    {
        public int WithdrawalOrderID { get; set; }
        public CustomerOrder WithdrawalOrder { get; set; }

        public int ItemID { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }

}
