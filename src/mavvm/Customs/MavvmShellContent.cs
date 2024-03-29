﻿using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using mavvm.Attibutes;
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

        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (this.Parent is ShellSection tab)
            {
                if (tab is null) return;
                tab.Route = ViewModel.Name + "Tab";
            }
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

