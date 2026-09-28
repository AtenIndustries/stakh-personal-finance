using Stakh.ViewModels;

namespace Stakh.Views;
public partial class AddBalancePage : ContentPage
{
    public AddBalancePage(AddBalanceViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}