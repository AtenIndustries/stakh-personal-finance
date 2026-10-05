using CommunityToolkit.Mvvm.ComponentModel;
using Stakh.Core.Services;
using Stakh.ViewModels;

namespace Stakh.Features.MonthBalances;
public class MonthBalanceViewModel : ObservableObject
{
    public int Id { get; set; }
    public int BalanceId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Month { get; set; }
    public int Year { get; set; }
    public List<ExpenseReportViewModel> ExpenseReports { get; set; } = [];
}
