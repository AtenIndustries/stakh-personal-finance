namespace Stakh.Features.MonthBalances;
public partial class AddMonthBalancePage : ContentPage
{
    public AddMonthBalancePage(AddMonthBalanceViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}