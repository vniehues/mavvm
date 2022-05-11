using System;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace mavvm
{
    public class MavvmResolveRouteFactory<TView, TViewModel> : RouteFactory where TView : ContentPage, new() where TViewModel : class, INotifyPropertyChanged
    {

        public override Element GetOrCreate(IServiceProvider services)
        {
            var serviceProvider = services != null ? services : MavvmContainer.ServiceProvider;

            var view = new TView
            {
                BindingContext = serviceProvider.GetRequiredService<TViewModel>()
            };

            if (view.BindingContext is IPageAware pageAware)
            {
                view.Disappearing -= (s, e) => pageAware.Disappearing();
                view.Appearing -= (s, e) => pageAware.Appearing();

                view.Disappearing += (s, e) => pageAware.Disappearing();
                view.Appearing += (s, e) => pageAware.Appearing();
            }

            return view;
        }

        public override Element GetOrCreate()
        {
            var view = new TView
            {
                BindingContext = MavvmContainer.ServiceProvider.GetRequiredService<TViewModel>()
            };

            if (view.BindingContext is IPageAware pageAware)
            {
                view.Disappearing -= (s, e) => pageAware.Disappearing();
                view.Appearing -= (s, e) => pageAware.Appearing();

                view.Disappearing += (s, e) => pageAware.Disappearing();
                view.Appearing += (s, e) => pageAware.Appearing();
            }

            return view;
        }
    }
}

