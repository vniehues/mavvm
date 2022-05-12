using System;
using CommunityToolkit.Mvvm.Input;
using mavvm;

namespace mavvmApp.ViewModels
{
	public partial class LastPageViewModel : BindableBase, INavigateToAware
	{

		[ICommand]
		async void GoBack()
		{
			await BaseMethods.GoBack(parameters: new NavigationParameters {{"testKey3","testValue3" }});
		}

		[ICommand]
		async void GoToSecondTabPage()
		{
			await BaseMethods.GoToViewModel<SecondTabPageViewModel>(parameters: new NavigationParameters { { "testKey4", "testValue4" } });
		}

		public void NavigatedTo(NavigationParameters parameters)
		{
			Console.WriteLine(parameters);
		}

        public LastPageViewModel()
		{
		}
	}
}

