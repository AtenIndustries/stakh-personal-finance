namespace Stakh.ViewModels
{
    public class IncomeViewModel
    {
        public int Id { get; set; }
        public int ExpenseReportId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}