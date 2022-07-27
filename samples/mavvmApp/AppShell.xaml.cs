using mavvm.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

namespace mavvmApp
{
    public partial class AppShell : IShellWithTabBar
    {
        public AppShell()
        {
            InitializeComponent();

            TabBar = MainTabbar;
        }

        public TabBar TabBar { get; }
    }
}
