using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;

namespace mavvm
{
    public static class MavvmBuilderExtensions
    {
        /// <summary>
        /// Adds a Route by registering the view with the corresponding viewmodel.
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="mauiApp"></param>
        /// <returns></returns>
        public static MauiAppBuilder AddRoute<TView, TViewModel>(this MauiAppBuilder builder)
            where TView : ContentPage, new()
            where TViewModel : BindableBase
        {
            var routeName = typeof(TViewModel).Name;
            Routing.UnRegisterRoute(routeName);
            Routing.RegisterRoute(routeName, new MavvmResolveRouteFactory<TView, TViewModel>());

            builder.Services.AddTransient<TViewModel>();

            return builder;
        }

        /// <summary>
        /// Registers the services in the service collection with the page resolver.
        /// Needs to be called AFTER services have been registered!
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void UseMavvm(this IServiceCollection serviceCollection)
        {
            MavvmContainer.RegisterServiceProvider(serviceCollection.BuildServiceProvider());
        }


        /// <summary>
        /// Registers the services in the service collection with the page resolver.
        /// Replaces MauiAppBuilder.Build()
        /// </summary>
        /// <param name="builder"></param>
        public static MauiApp BuildWithMavvm(this MauiAppBuilder builder)
        {
            var mauiApp = builder.Build();

            MavvmContainer.ServiceProvider = mauiApp.Services;

            return mauiApp;
        }
    }
}

