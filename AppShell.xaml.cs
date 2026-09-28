using Stakh.Views;

namespace Stakh;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddBalancePage), typeof(AddBalancePage));
	}
}
