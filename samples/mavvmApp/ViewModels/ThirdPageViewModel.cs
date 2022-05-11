using System;
using CommunityToolkit.Mvvm.Input;
using mavvm;

namespace mavvmApp.ViewModels
{
	public partial class ThirdPageViewModel : BindableBase, INavigateToAware
	{

		[ICommand]
		async void GoBack()
		{
			await BaseMethods.GoBack(parameters: new NavigationParameters {{"testKey1","testValue1" }});
		}

        public void NavigatedTo(NavigationParameters parameters)
		{
			Console.WriteLine(parameters);
		}

        public ThirdPageViewModel()
		{
		}
	}
}

