namespace Stakh.ViewModels
{
    public class ExpenseReportViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public List<ExpenseRecordCategoryViewModel> ExpenseRecordCategories { get; set; } = [];
        public List<ReserveFundViewModel> ReserveFunds { get; set; } = [];
        public List<IncomeViewModel> Incomes { get; set; } = [];
    }
}