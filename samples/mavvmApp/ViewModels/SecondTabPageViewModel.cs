using System;
using mavvm;

namespace mavvmApp.ViewModels
{
    public class SecondTabPageViewModel : BindableBase
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

        public SecondTabPageViewModel()
        {
            Title = "Second Tab";
        }
    }
}

