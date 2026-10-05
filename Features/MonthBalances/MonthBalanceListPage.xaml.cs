using Stakh.ViewModels; 

namespace Stakh.Features.MonthBalances;

public partial class MonthBalanceListPage : ContentPage
{
    public MonthBalanceListViewModel Balance { get; }
    private readonly MonthBalanceListViewModel _vm;

    public MonthBalanceListPage(MonthBalanceListViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadMonthBalanceListCommand.ExecuteAsync(null);
    }
}
