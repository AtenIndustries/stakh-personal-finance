using Microsoft.Extensions.Logging;
using Stakh.ViewModels;
using Stakh.Views;

namespace Stakh;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.Services.AddSingleton<Data.DatabaseService>();

		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<AddBalanceViewModel>();
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
