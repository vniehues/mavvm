using System;
using System.Collections.Generic;
using System.ComponentModel;
using mavvm;
using mavvm.Navigation;
using Microsoft.Maui.Controls;

namespace mavvmApp.ViewModels
{
    public class MainPageViewModel : BindableBase
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
                SetPropertyValue(ref _title, value);
            }
        }

        private int _count;
        public int Count
        {
            get { return this._count; }
            set { this.SetPropertyValue(ref this._count, value); }
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
            await Navigation.GoToViewModel<SecondPageViewModel>(true, new Dictionary<string, object>{ { "countParam", Count } });
        }
    }
}

