using Stakh.Features.Balances;
using Stakh.Features.ExpenseReports;
using Stakh.Features.MonthBalances;

namespace Stakh;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddBalancePage), typeof(AddBalancePage));
		Routing.RegisterRoute(nameof(AddMonthBalancePage), typeof(AddMonthBalancePage));
		Routing.RegisterRoute(nameof(MonthBalanceListPage), typeof(MonthBalanceListPage));
		Routing.RegisterRoute(nameof(ExpenseReportListPage), typeof(ExpenseReportListPage));
		Routing.RegisterRoute(nameof(AddExpenseReportPage), typeof(AddExpenseReportPage));
	}
}
