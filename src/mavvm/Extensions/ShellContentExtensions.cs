using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace mavvm
{
    [ContentProperty(nameof(ViewModel))]
    public class GetOrCreateContent : IMarkupExtension
    {
        public Type ViewModel { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) =>
            new DataTemplate(() => Routing.GetOrCreateContent(ViewModel.Name));
    }
}

