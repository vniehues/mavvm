using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace mavvm
{
    public static class BaseMethods
    {
        public static Task GoBack(bool replaceStack = false, Dictionary<string, object> parameters = null)
        {
            var path = (replaceStack ? "//" : "") + "..";

            if (parameters is null)
                return Shell.Current.GoToAsync(path);
            else
                return Shell.Current.GoToAsync(path, parameters);
        }

        public static Task GoToViewModel<TViewModel>(bool replaceStack = false, Dictionary<string, object> parameters = null)
        {
            var path = (replaceStack ? "//" : "") + typeof(TViewModel).Name;

            if (parameters is null)
                return Shell.Current.GoToAsync(path);
            else
                return Shell.Current.GoToAsync(path, parameters);
        }

        public static Task ShowAlert(string title, string message, string cancel)
        {
            return Shell.Current.DisplayAlert(title, message, cancel);
        }

        public static Task<bool> ShowAlert(string title, string message, string cancel, string accept)
        {
            return Shell.Current.DisplayAlert(title, message, accept, cancel);
        }

        public static Task<string> ShowActionSheet(string title, string cancel, string[] buttons, string destruction = null)
        {
            return Shell.Current.DisplayActionSheet(title, cancel, destruction, buttons);
        }
    }
}

