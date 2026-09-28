namespace Stakh.ViewModels
{
    public class ReserveFundViewModel
    {
        public int Id { get; set; }
        public int ExpenseReportId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ReserveFundRecordViewModel> ReserveFundRecords { get; set; } = [];
    }

    public class ReserveFundRecordViewModel
    {
        public int Id { get; set; }
        public int ReserveFundId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}