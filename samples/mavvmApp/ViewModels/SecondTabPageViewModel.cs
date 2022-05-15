using System;
using mavvm;
using mavvm.Attibutes;

namespace mavvmApp.ViewModels
{
    [SectionRoute("main")]
    public class SecondTabPageViewModel : BindableBase, INavigationAware
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

        public void NavigatedTo(NavigationParameters parameters)
        {
        }

        public void NavigatedBackTo(NavigationParameters parameters)
        {
        }
    }
}

