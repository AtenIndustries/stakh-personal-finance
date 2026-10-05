using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stakh.Core.Services;
using Stakh.Core.Models;

namespace Stakh.Features.ExpenseReports;

[QueryProperty(nameof(MonthBalanceId), "monthBalanceId")]
public partial class AddExpenseReportViewModel(DatabaseService db) : ObservableObject
{

    [ObservableProperty]
    private int monthBalanceId;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string name = string.Empty;
 
    private bool CanSave() => !string.IsNullOrWhiteSpace(Name);


    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task SaveAsync()
    {
        await db.CreateAsync(new ExpenseReport()
        {
            MonthBalanceId = MonthBalanceId,
            Name = Name
        });
        await Shell.Current.GoToAsync(".."); // back to BalanceList
    }
}
