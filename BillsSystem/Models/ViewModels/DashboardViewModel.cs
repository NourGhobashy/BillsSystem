namespace BillsSystem.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int CustomerCount { get; set; }
        public int BillCount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public int UnpaidBillsCount { get; set; }
        public int PaidBillsCount { get; set; }
    }


}
