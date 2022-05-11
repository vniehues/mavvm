using System;
using mavvmApp.Interfaces;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;
using mavvm;
using CommunityToolkit.Mvvm.Input;

namespace mavvmApp.ViewModels
{
    [QueryProperty(nameof(Count), "countParam")]
    public partial class SecondPageViewModel : BindableBase, IPageAware, INavigationAware
    {
        [ICommand]
        async void GoBack()
        {
            await BaseMethods.GoBack();
        }

        [ICommand]
        async void GoToThirdPage()
        {
            await BaseMethods.GoToViewModel<ThirdPageViewModel>(parameters: new NavigationParameters { { "testKey2", "testValue2" } });
        }

        string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetPropertyValue(ref _title, value);
            }
        }

        private int _count;
        public int Count
        {
            get { return this._count; }
            set { this.SetPropertyValue(ref this._count, value); }
        }

        public Command LogCountCommand { get; set; }

        IConsoleService _consoleService;

        public SecondPageViewModel(IConsoleService consoleService)
        {
            Title = "SecondPageViewmodel";

            _consoleService = consoleService;

            LogCountCommand = new Command(LogCount);
        }

        async void LogCount()
        {
            _consoleService.Log(Count.ToString());

            var optionSheet = await BaseMethods.ShowActionSheet("Action Sheet", "Close", new string[] { "1", "2" }, "button dest");
            _consoleService.Log(optionSheet);

            await BaseMethods.ShowAlert("Count", $"Count is {Count}", "Cancel");

            var optionAlert = await BaseMethods.ShowAlert("Count", $"Count is {Count}", "Cancel", "Ok");
            _consoleService.Log(optionAlert.ToString());
        }

        public void Appearing()
        {
            _consoleService.Log("Appearing");
        }

        public void Disappearing()
        {
            _consoleService.Log("Disappearing");
        }

        public void NavigatedBackTo(NavigationParameters parameters)
        {
            Console.WriteLine(parameters);
        }

        public void NavigatedTo(NavigationParameters parameters)
        {
            Console.WriteLine(parameters);
        }
    }
}

