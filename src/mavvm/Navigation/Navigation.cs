using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace mavvm
{
    public static class Navigation
    {
        public static Task GoBack(bool replaceStack = false)
        {
            return Shell.Current.GoToAsync("..");
        }

        public static Task GoToViewModel<TViewModel>(bool replaceStack = false, Dictionary<string, object> parameters = null)
        {
            var path = (replaceStack ? "//" : "") + typeof(TViewModel).Name;

            if (parameters is null)
                return Shell.Current.GoToAsync(path);
            else
                return Shell.Current.GoToAsync(path, parameters);
        }
    }
}

