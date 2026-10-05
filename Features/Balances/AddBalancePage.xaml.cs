namespace Stakh.Features.Balances;
public partial class AddBalancePage : ContentPage
{
    public AddBalancePage(AddBalanceViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}