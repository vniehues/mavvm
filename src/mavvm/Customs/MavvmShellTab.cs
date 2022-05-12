using System;
using System.Reflection;
using mavvm.Attibutes;
using Microsoft.Maui.Controls;

namespace mavvm.Customs
{
	public class MavvmShellTab : Tab
	{
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            var vmContent = (child as MavvmShellContent);
            var vm = vmContent?.ViewModel;
            if (vm is null) return;

            var attrib = vm.GetCustomAttribute<TabRouteAttribute>();
            if (attrib is null) return;

            (child as MavvmShellContent).Route = attrib.TabRoute;
        }
    }
}

