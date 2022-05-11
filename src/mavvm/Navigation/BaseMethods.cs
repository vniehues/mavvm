using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace mavvm
{
    public static class BaseMethods
    {
        public static async Task GoBack(bool replaceStack = false, NavigationParameters parameters = null, bool animate = true)
        {
            var path = (replaceStack ? "//" : "") + "..";

            if (parameters is null)
            {
                await Shell.Current.GoToAsync(path, animate);
            }
            else
            {
                await Shell.Current.GoToAsync(path, animate, parameters);

                if ((Shell.Current?.CurrentItem?.CurrentItem as IShellSectionController)?.PresentedPage.BindingContext is INavigateBackToAware vm)
                {
                    vm.NavigatedBackTo(parameters);
                }

            }
        }

        public static async Task GoToSection(string sectionRoute, NavigationParameters parameters = null, bool animate = true)
        {
            var path = $"//{sectionRoute}";

            if (parameters is null)
            {
                await Shell.Current.GoToAsync(path, animate);
            }
            else
            {
                await Shell.Current.GoToAsync(path, false, parameters);

                //HACK: Shell doesn'T immediately know about PresentedPage. 
                await Task.Delay(50);

                if ((Shell.Current?.CurrentItem?.CurrentItem as IShellSectionController)?.PresentedPage?.BindingContext is INavigateToAware vmTo)
                {
                    vmTo.NavigatedTo(parameters);
                }
            }
        }

        public static async Task GoToViewModel<TViewModel>(bool replaceStack = false, NavigationParameters parameters = null)
        {
            var vmType = typeof(TViewModel);
            var path = (replaceStack ? "//" : "") + vmType.Name;

            if (parameters is null)
            {
                await Shell.Current.GoToAsync(path);
            }
            else
            {
                await Shell.Current.GoToAsync(path, parameters);

                if ((Shell.Current?.CurrentItem?.CurrentItem as IShellSectionController)?.PresentedPage.BindingContext is INavigateToAware vm)
                {
                    vm.NavigatedTo(parameters);
                }
            }
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

