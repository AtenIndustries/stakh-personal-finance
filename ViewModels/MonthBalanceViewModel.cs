using CommunityToolkit.Mvvm.ComponentModel;
using Stakh.Data;

namespace Stakh.ViewModels
{
    public class MonthBalanceViewModel(DatabaseService db) : ObservableObject
    {
        public int Id { get; set; }
        public int BalanceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Month { get; set; }
        public int Year { get; set; }
        public List<ExpenseReportViewModel> ExpenseReports { get; set; } = []; 
    }
}