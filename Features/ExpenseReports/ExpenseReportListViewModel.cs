using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stakh.Core.Services;
using Stakh.Core.Models;

namespace Stakh.Features.ExpenseReports
{
    [QueryProperty(nameof(MonthBalanceId), "MonthBalanceId")]
    public partial class ExpenseReportListViewModel(DatabaseService db) : ObservableObject
    {
        [ObservableProperty]
        private int monthBalanceId;   // use the same type as balance.Id  
        public ObservableCollection<ExpenseReportEntryViewModel> ExpenseReports { get; } = [];

        [RelayCommand]
        private async Task LoadExpenseReportsAsync()
        {
            var dataExpenseReports = await db.GetAllAsync<ExpenseReport>();
            ExpenseReports.Clear();
            foreach (var expenseReport in dataExpenseReports)
            {
                ExpenseReports.Add(new ExpenseReportEntryViewModel()
                {
                    Id = expenseReport.Id,
                    Name = expenseReport.Name,
                    MonthBalanceId = expenseReport.MonthBalanceId
                });
            }
        }

        [RelayCommand]
        private async Task AddExpenseReportAsync() => await Shell.Current.GoToAsync($"{nameof(AddExpenseReportPage)}?monthBalanceId={MonthBalanceId}");
 
    }
}