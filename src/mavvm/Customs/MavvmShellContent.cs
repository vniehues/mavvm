using System;
using Microsoft.Maui.Controls;

namespace mavvm
{
    public class MavvmShellContent : ShellContent
    {
        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(Type),
            typeof(MavvmShellContent), propertyChanged: ViewModelChanged);

        public Type ViewModel
        {
            get => (Type)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        static void ViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var shellcontent = bindable as MavvmShellContent;

            shellcontent.SetContentTemplate();
        }

        public MavvmShellContent()
        {
            SetContentTemplate();
        }

        void SetContentTemplate()
        {
            ContentTemplate = new DataTemplate(() => Routing.GetOrCreateContent(ViewModel.Name));
        }
    }
}

