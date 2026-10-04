using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stakh.Data;
using Stakh.Models;
using Stakh.Views;

namespace Stakh.ViewModels
{
    [QueryProperty(nameof(BalanceId), "BalanceId")]
    public partial class BalanceDetailsViewModel(DatabaseService db) : ObservableObject
    {
        
        [ObservableProperty]
        private int balanceId;   // use the same type as balance.Id (int, Guid, string...)
 
        public string Name { get; set; } = string.Empty;
        public ObservableCollection<MonthBalanceViewModel> MonthBalances { get; set; } = [];

        [RelayCommand]
        private async Task LoadBalanceDetailsAsync()
        {
            var balance = await db.LoadBalanceAsync(BalanceId);
            MonthBalances.Clear();
            foreach (var monthBalance in balance.MonthBalances)
            {
                MonthBalances.Add(new MonthBalanceViewModel(db)
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