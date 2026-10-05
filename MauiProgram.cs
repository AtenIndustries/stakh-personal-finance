using Microsoft.Extensions.Logging;
using Stakh.Features.Balances;
using Stakh.ViewModels;
using Stakh.Views;

namespace Stakh;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.Services.AddSingleton<Core.Services.DatabaseService>();

		builder.Services.AddTransient<BalanceListViewModel>();
		builder.Services.AddTransient<BalanceList>();
		builder.Services.AddTransient<AddBalanceViewModel>();
		builder.Services.AddTransient<AddMonthBalanceViewModel>();
		builder.Services.AddTransient<BalanceDetailsViewModel>();
		builder.Services.AddTransient<AddBalancePage>();

		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
