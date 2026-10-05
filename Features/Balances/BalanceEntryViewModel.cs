using CommunityToolkit.Mvvm.ComponentModel;
using Stakh.Core.Services;

namespace Stakh.Features.Balances
{
    public class BalanceEntryViewModel : ObservableObject
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
    }
}