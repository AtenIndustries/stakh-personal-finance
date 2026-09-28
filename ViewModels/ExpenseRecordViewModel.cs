namespace Stakh.ViewModels
{
    public class ExpenseRecordViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RecordCategoryId { get; set; }
        public int ExpenseReportId { get; set; }
        public decimal Reserved { get; set; }
        public decimal Executed { get; set; }
        public bool Closed { get; set; }
    }

    public class ExpenseRecordCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ExpenseRecordViewModel> ExpenseRecords { get; set; } = [];
    }
}