using System;
using Microsoft.Maui.Controls;

namespace mavvm.Customs
{
    public class CustomShellContent : ShellContent
    {

        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(Type),
            typeof(CustomShellContent));

        public Type ViewModel
        {
            get => (Type)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        public CustomShellContent()
        {
            ContentTemplate = new DataTemplate(() => Routing.GetOrCreateContent(ViewModel.Name));
        }
    }
}

