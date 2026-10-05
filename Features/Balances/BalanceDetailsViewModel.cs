using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stakh.Core.Services;
using Stakh.Core.Models;
using Stakh.Views;

namespace Stakh.Features.Balances
{
    [QueryProperty(nameof(BalanceId), "BalanceId")]
    public partial class BalanceDetailsViewModel(DatabaseService db) : ObservableObject
    {
        
        [ObservableProperty]
        private int balanceId;   // use the same type as balance.Id  
 
        public string Name { get; set; } = string.Empty;
        public ObservableCollection<MonthBalanceEntryViewModel> MonthBalances { get; set; } = [];

        [RelayCommand]
        private async Task LoadBalanceDetailsAsync()
        {
            var balance = await db.LoadBalanceAsync(BalanceId);
            MonthBalances.Clear();
            foreach (var monthBalance in balance.MonthBalances)
            {
                MonthBalances.Add(new MonthBalanceEntryViewModel(db)
                {
                    Id = monthBalance.Id,
                    Month = monthBalance.Month,
                    Year = monthBalance.Year,
                    BalanceId = monthBalance.BalanceId
                });
            }
        }

        [RelayCommand]
        private async Task AddMonthBalanceAsync() => await Shell.Current.GoToAsync($"{nameof(AddMonthBalancePage)}?balanceId={balanceId}");

    }
}