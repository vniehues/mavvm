using System;
using mavvmApp.Interfaces;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;
using mavvm.Implementations;

namespace mavvmApp.ViewModels
{
    [QueryProperty(nameof(Count), "countParam")]
    public class SecondPageViewModel : BindableBase
    {
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
            _consoleService = consoleService;

               LogCountCommand = new Command(CountUp);
        }

        void CountUp()
        {
        }
    }
}

