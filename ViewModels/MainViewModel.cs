using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stakh.Data;
using Stakh.Models;
using Stakh.Views;

namespace Stakh.ViewModels
{
    public partial class MainViewModel(DatabaseService db) : ObservableObject
    {
        private readonly DatabaseService _db = db;
        public ObservableCollection<BalanceViewModel> Balances { get; } = [];

        [RelayCommand]
        private async Task LoadBalancesAsync()
        {
            var dataBalances = await _db.GetAllAsync<Balance>();
            Balances.Clear();
            foreach (var balance in dataBalances)
            {
                Balances.Add(new BalanceViewModel(){ //TODO: Use AutoMapper to map Balance to BalanceViewModel
                    Id = balance.Id,
                    Name = balance.Name
                });
            }
        }

        [RelayCommand]
        private async Task AddBalanceAsync(string name) => await Shell.Current.GoToAsync(nameof(AddBalancePage));
    }
}