using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stakh.Core.Services;
using Stakh.Core.Models;

namespace Stakh.ViewModels;
public partial class AddBalanceViewModel(DatabaseService db) : ObservableObject
{ 

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string name = string.Empty;
 
    private bool CanSave() => !string.IsNullOrWhiteSpace(Name);

    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task SaveAsync()
    { 
        await db.CreateAsync(new Balance { Name = Name.Trim() });
        await Shell.Current.GoToAsync(".."); // back to BalanceList
    }
}
