using System;
using System.Collections.Generic;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using mavvm;
using Microsoft.Maui.Controls;

namespace mavvmApp.ViewModels
{
    public class MainPageViewModel : ObservableObject
    {
        string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private int _count;
        public int Count
        {
            get { return this._count; }
            set { this.SetProperty(ref this._count, value); }
        }

        public Command CountUpCommand { get; set; }
        public Command NavigateCommand { get; set; }
        public MainPageViewModel()
        {
            CountUpCommand = new Command(CountUp);
            NavigateCommand = new Command(Navigate);

            Title = "First Tab";
        }

        void CountUp()
        {
            Count++;
        }

        async void Navigate()
        {
            await BaseMethods.GoToSection<SecondTabPageViewModel>("main",parameters: new NavigationParameters{ { "countParam", Count } });
        }
    }
}

