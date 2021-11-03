using System;
using mavvm.Factories;
using mavvm.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;

namespace mavvm.Extensions
{
    public static class BuilderExtensions
    {
        public static MauiAppBuilder AddRoute<TView, TViewModel>(this MauiAppBuilder mauiApp)
            where TView : ContentPage, new()
            where TViewModel : BaseViewModel
        {
            var routeName = typeof(TViewModel).Name;
            Routing.UnRegisterRoute(routeName);
            Routing.RegisterRoute(routeName, new ResolveRouteFactory<TView, TViewModel>());

            mauiApp.Services.AddTransient<TViewModel>();

            return mauiApp;
        }

        public static MauiApp BuildWithContainer(this MauiAppBuilder mauiAppBuilder)
        {
            var mauiApp = mauiAppBuilder.Build();

            MavvmContainer.ServiceProvider = mauiApp.Services;

            return mauiApp;
        }
    }
}

