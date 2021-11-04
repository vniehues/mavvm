using System;
using Microsoft.Maui.Controls;

namespace mavvm
{
    public class MavvmShellContent : ShellContent
    {

        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(Type),
            typeof(MavvmShellContent));

        public Type ViewModel
        {
            get => (Type)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        public MavvmShellContent()
        {
            ContentTemplate = new DataTemplate(() => Routing.GetOrCreateContent(ViewModel.Name));
        }
    }
}

