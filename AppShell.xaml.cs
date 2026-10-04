using Stakh.Views;

namespace Stakh;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddBalancePage), typeof(AddBalancePage));
		Routing.RegisterRoute(nameof(AddMonthBalancePage), typeof(AddMonthBalancePage));
		Routing.RegisterRoute(nameof(BalanceDetailsPage), typeof(BalanceDetailsPage));
	}
}
