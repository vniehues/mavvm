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
            await BaseMethods.GoBack();
        }

        [ICommand]
        async void GoToLastPage()
        {
            await BaseMethods.GoToViewModel<LastPageViewModel>(parameters: new NavigationParameters { { "testKey2", "testValue2" } });
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

