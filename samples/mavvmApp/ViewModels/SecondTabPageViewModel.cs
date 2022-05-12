using System;
using mavvm;
using mavvm.Attibutes;

namespace mavvmApp.ViewModels
{
    [TabRoute("secondTabPage")]
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

