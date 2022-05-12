using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using mavvmApp.ViewModels;
using mavvmApp.Views;
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
				.AddRoute<SecondPage, SecondPageViewModel>()
				.AddRoute<ThirdPage, ThirdPageViewModel>()
				.AddRoute<LastPage, LastPageViewModel>()
				.AddRoute<SecondTabPage, SecondTabPageViewModel>();

			builder.Services.AddSingleton<IConsoleService, ConsoleService>();

			return builder.BuildWithMavvm();
		}
	}
}