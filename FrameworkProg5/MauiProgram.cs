using Microsoft.Extensions.Logging;
using FrameworkProg5.View;
using FrameworkProg5.Services;

namespace FrameworkProg5;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

		builder.Services.AddSingleton<PokemonService>();

		builder.Services.AddSingleton<PokemonViewModels>();
		builder.Services.AddTransient<PokemonDetailsViewModel>();	

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailsPage>();

		return builder.Build();
	}
}
