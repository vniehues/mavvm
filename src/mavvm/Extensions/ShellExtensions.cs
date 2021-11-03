using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mavvm.ViewModels;
using Microsoft.Maui.Controls;

namespace mavvm.Extensions
{
    public static class ShellExtensions
    {
        public static Task GoToViewModel<TViewModel>(this Shell shell, Dictionary<string, object> parameters = null)
        {
            if (parameters is null)
                return Shell.Current.GoToAsync(typeof(TViewModel).Name);
            else
                return Shell.Current.GoToAsync(typeof(TViewModel).Name, parameters);
        }
    }
}

