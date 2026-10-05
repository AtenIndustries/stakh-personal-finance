using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stakh.Core.Services;
using Stakh.Core.Models;

namespace Stakh.Features.MonthBalances;

[QueryProperty(nameof(BalanceId), "balanceId")]
public partial class AddMonthBalanceViewModel(DatabaseService db) : ObservableObject
{

    [ObservableProperty]
    private int balanceId;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string? yearText;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string? monthText;

    private bool CanSave()
    {
        return         int.TryParse(YearText, out var y) && y > 0 &&
        int.TryParse(MonthText, out var m) && m is >= 1 and <= 12;
    }


    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task SaveAsync()
    {
        await db.CreateAsync(new MonthBalance()
        {
            BalanceId = BalanceId,
            Year = int.Parse(YearText!),
            Month = int.Parse(MonthText!)
        });
        await Shell.Current.GoToAsync(".."); // back to BalanceList
    }
}
