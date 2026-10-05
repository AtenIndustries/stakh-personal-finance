using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stakh.Core.Services;
using Stakh.Core.Models;
using Stakh.Views;

namespace Stakh.Features.Balances
{
    public partial class BalanceListViewModel(DatabaseService db) : ObservableObject
    {
        public ObservableCollection<BalanceDetailsViewModel> Balances { get; } = [];

        [RelayCommand]
        private async Task LoadBalancesAsync()
        {
            var dataBalances = await db.GetAllAsync<Balance>();
            Balances.Clear();
            foreach (var balance in dataBalances)
            {
                Balances.Add(new BalanceDetailsViewModel(db)
                { //TODO: Use AutoMapper to map Balance to BalanceDetailsViewModel
                    BalanceId = balance.Id,
                    Name = balance.Name
                });
            }
        }

        [RelayCommand]
        private async Task AddBalanceAsync(string name) => await Shell.Current.GoToAsync(nameof(AddBalancePage));

        [RelayCommand]
        private async Task LoadBalanceAsync(BalanceDetailsViewModel balance)
        {
            if (balance == null) return;
            try
            {
                await Shell.Current.GoToAsync($"{nameof(BalanceDetailsPage)}?BalanceId={balance.BalanceId}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // temporarily, to see it on screen:
                await Shell.Current.DisplayAlert("Navigation error", ex.ToString(), "OK");
            }
        }
    }
}