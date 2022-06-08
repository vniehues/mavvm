using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using mavvm.Attibutes;
using mavvm.Interfaces;
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

        public static async Task GoToViewModel<TViewModel>(bool replaceStack, NavigationParameters parameters = null)
        {
            var vmType = typeof(TViewModel);
            var path = (replaceStack ? "//" : "") + vmType.Name;

            SelectCorrectTab(vmType);

            //HACK: Shell doesn't immediately know about CurrentPage. 
            await Task.Delay(50);

            if (Shell.Current?.CurrentPage?.BindingContext?.GetType() != vmType)
            {
                if (parameters is null)
                {
                    await Shell.Current.GoToAsync(path);
                }
                else
                {
                    await Shell.Current.GoToAsync(path, parameters);
                }
            }

            if (Shell.Current?.CurrentPage?.BindingContext is INavigateToAware vm)
            {
                vm.NavigatedTo(parameters);
            }
        }

        public static async Task GoToViewModel<TViewModel>(NavigationParameters parameters = null)
        {
            var vmType = typeof(TViewModel);
            var path = vmType.Name;

            SelectCorrectTab(vmType);

            //HACK: Shell doesn't immediately know about CurrentPage. 
            await Task.Delay(50);

            if (Shell.Current?.CurrentPage?.BindingContext?.GetType() != vmType)
            {
                if (parameters is null)
                {
                    await Shell.Current.GoToAsync(path);
                }
                else
                {
                    await Shell.Current.GoToAsync(path, parameters);
                }
            }

            if (Shell.Current?.CurrentPage?.BindingContext is INavigateToAware vm)
            {
                vm.NavigatedTo(parameters);
            }
        }

        public static async Task GoToViewModel<TViewModel>(Type[] intermediates, NavigationParameters parameters = null)
        {
            var vmType = typeof(TViewModel);

            var path = "";

            foreach (var vmStep in intermediates)
            {
                path += $"{vmStep.Name}/";
            }
            
            path += vmType.Name;

            SelectCorrectTab(intermediates.Length > 0 ? intermediates[0] : vmType);

            //HACK: Shell doesn't immediately know about CurrentPage. 
            await Task.Delay(50);

            if (Shell.Current?.CurrentPage?.BindingContext?.GetType() != vmType)
            {
                if (parameters is null)
                {
                    await Shell.Current.GoToAsync(path);
                }
                else
                {
                    await Shell.Current.GoToAsync(path, parameters);
                }
            }

            if (Shell.Current?.CurrentPage?.BindingContext is INavigateToAware vm)
            {
                vm.NavigatedTo(parameters);
            }
        }
        public static async Task GoToViewModel<TViewModel>(Type intermediate, NavigationParameters parameters = null)
        {
            var vmType = typeof(TViewModel);

            var path = "";

            if (intermediate is not null)
            {
                path += $"{intermediate.Name}/";
            }
            
            path += vmType.Name;

            SelectCorrectTab(intermediate ?? vmType);

            //HACK: Shell doesn't immediately know about CurrentPage. 
            await Task.Delay(50);

            if (Shell.Current?.CurrentPage?.BindingContext?.GetType() != vmType)
            {
                if (parameters is null)
                {
                    await Shell.Current.GoToAsync(path);
                }
                else
                {
                    await Shell.Current.GoToAsync(path, parameters);
                }
            }

            if (Shell.Current?.CurrentPage?.BindingContext is INavigateToAware vm)
            {
                vm.NavigatedTo(parameters);
            }
        }

        static void SelectCorrectTab(Type viewModelType)
        {
            if (Application.Current?.MainPage is IShellWithTabBar shell)
            {              
                var tabItem = shell
                    .TabBar?
                    .Items
                    .FirstOrDefault(x => x.Route == viewModelType.Name + "Tab");

                if (tabItem is object)
                {
                    shell.TabBar.CurrentItem = tabItem;
                }
            }

            var sectionAttribute = viewModelType.GetCustomAttribute<SectionRouteAttribute>();
            if (sectionAttribute is object)
            {
                var sectionItem = Shell.Current.Items.FirstOrDefault(x => x.Route == sectionAttribute.SectionRoute);

                if (sectionItem is object)
                {
                    Shell.Current.CurrentItem = sectionItem;
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

