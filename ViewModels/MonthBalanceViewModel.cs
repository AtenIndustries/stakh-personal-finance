namespace Stakh.ViewModels
{
    public class MonthBalanceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Month { get; set; }
        public int Year { get; set; }
        public List<ExpenseReportViewModel> ExpenseReports { get; set; } = []; 
    }
}