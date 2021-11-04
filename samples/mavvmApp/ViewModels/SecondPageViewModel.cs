using System;
using mavvmApp.Interfaces;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;
using mavvm;

namespace mavvmApp.ViewModels
{
    [QueryProperty(nameof(Count), "countParam")]
    public class SecondPageViewModel : BindableBase
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

        public Command LogCountCommand { get; set; }

        IConsoleService _consoleService;

        public SecondPageViewModel(IConsoleService consoleService)
        {
            Title = "SecondPageViewmodel";

            _consoleService = consoleService;

            LogCountCommand = new Command(CountUp);
        }

        void CountUp()
        {
        }
    }
}

