using CommunityToolkit.Mvvm.ComponentModel;
using Stakh.Core.Services;

namespace Stakh.Features.Balances
{
    public class MonthBalanceEntryViewModel(DatabaseService db) : ObservableObject
    {
        public int Id { get; set; }
        public int BalanceId { get; set; } 
        public int Month { get; set; }
        public int Year { get; set; } 
    }
}