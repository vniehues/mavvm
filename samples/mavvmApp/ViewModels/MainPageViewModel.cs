using System;
using System.Collections.Generic;
using System.ComponentModel;
using mavvm;
using Microsoft.Maui.Controls;

namespace mavvmApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
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
        }

        void CountUp()
        {
            Count++;
        }

        void Navigate()
        {
            Shell.Current.GoToViewModel<SecondPageViewModel>(new Dictionary<string, object>{ { "countParam", Count } });
        }
    }
}

