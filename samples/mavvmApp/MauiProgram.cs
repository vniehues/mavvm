using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using mavvmApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using mavvmApp.Services;
using mavvmApp.Interfaces;
using mavvm;

namespace mavvmApp
{
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
				})
				.AddRoute<MainPage, MainPageViewModel>()
				.AddRoute<SecondPage, SecondPageViewModel>();

			builder.Services.AddSingleton<IConsoleService, ConsoleService>();

			var mauiApp = builder.BuildWithContainer();

			return mauiApp;
		}
	}
}