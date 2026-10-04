using Stakh.ViewModels; 

namespace Stakh.Views;

public partial class BalanceDetailsPage : ContentPage
{
    public BalanceDetailsViewModel Balance { get; }
    private readonly BalanceDetailsViewModel _vm;

    public BalanceDetailsPage(BalanceDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadBalanceDetailsCommand.ExecuteAsync(null);
    }
}
