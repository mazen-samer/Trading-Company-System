namespace Trading_Company.Models
{
    public class WithdrawalOrderDetail
    {
        public int WithdrawalOrderID { get; set; }
        public WithdrawalOrder WithdrawalOrder { get; set; }

        public int ItemID { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }

}
