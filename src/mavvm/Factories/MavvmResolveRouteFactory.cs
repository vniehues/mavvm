using System;
using mavvm.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace mavvm.Factories
{
    public class MavvmResolveRouteFactory<TView, TViewModel> : RouteFactory where TView : ContentPage, new() where TViewModel : BindableBase
    {
        public override Element GetOrCreate()
        {
            var view = new TView
            {
                BindingContext = MavvmContainer.ServiceProvider.GetRequiredService<TViewModel>()
            };

            //if (view.BindingContext is IPageAware pageAware)
            //{
            //    view.Disappearing += (s, e) => pageAware.Disappearing();
            //    view.Appearing += (s, e) => pageAware.Appearing();
            //}

            return view;
        } 
    }
}

