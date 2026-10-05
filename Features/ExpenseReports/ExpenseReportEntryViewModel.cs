using CommunityToolkit.Mvvm.ComponentModel;
using Stakh.Core.Services;

namespace Stakh.Features.ExpenseReports
{
    public class ExpenseReportEntryViewModel : ObservableObject
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public int MonthBalanceId { get; set; } 
    }
}