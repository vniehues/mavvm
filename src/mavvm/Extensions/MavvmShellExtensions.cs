﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace mavvm
{
    public static class MavvmShellExtensions
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

