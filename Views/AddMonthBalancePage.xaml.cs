using Stakh.ViewModels;

namespace Stakh.Views;
public partial class AddMonthBalancePage : ContentPage
{
    public AddMonthBalancePage(AddMonthBalanceViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}