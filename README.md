# mavvm 
[![NuGet version (mavvm)](https://img.shields.io/nuget/v/mavvm.svg?style=for-the-badge&color=green)](https://www.nuget.org/packages/mavvm/)

mavvm is a framework for .NET MAUI and Shell. It allows you to use the MVVM architecture you know and love from Xamarin
applications with minimal configuration and overhead.

## Installation

Use the package manager to install mavvm.

```
Install-Package mavvm
```

# Usage
**It is important to use Shell! [Click here to learn how to use it.](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/create)**

As you can see from the tables below, the configuration is minimal.

1. ShellContent does not need a route property anymore. It only needs the corresponding ViewModel and will create the Route and BindingContext by itself.
2. In `MauiProgram.cs` you need to change `builder.Build();` to `builder.BuildWithContainer();` to make sure that the container is registered and can be used by mavvm.
3. Also in `MauiProgram.cs` you need to add every Page in your App with the corresponding ViewModel using the `.AddRoute<TView, TViewModel>()` extension.




<table>
 <tr>
    <td style="text-align: center"><b style="font-size:20px">Old</b> (AppShell.xaml)</td>
    <td style="text-align: center"><b style="font-size:20px">New</b> (AppShell.xaml)</td>
 </tr>
 <tr>
    <td>

```
<?xml version="1.0" encoding="UTF-8"?>
<Shell xmlns="http://xamarin.com/schemas/2014/forms"
       xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
       xmlns:views="clr-namespace:Xaminals.Views"
       x:Class="Xaminals.AppShell">
       
        <ShellItem Route="cats">
            <ShellContent Title="Cats"
                          Icon="cat.png"
                          ContentTemplate="{DataTemplate views:CatsPage}" />
        </ShellItem>
        <TabBar>
            <Tab Title="Second" Route="Second">
                <ShellContent Title="Elephants"
                      Icon="elephant.png"
                      ContentTemplate="{DataTemplate views:ElephantsPage}" />
            </Tab>
            <Tab Title="Second 2" Route="Third">
                <ShellContent Title="Bears"
                      Icon="bear.png"
                      ContentTemplate="{DataTemplate views:BearsPage}" />
            </Tab>
    </TabBar>
</Shell>
```

</td>
    <td>

```
<?xml version="1.0" encoding="UTF-8"?>
<Shell
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
    xmlns:viewmodels="clr-namespace:mavvmApp.ViewModels"
    xmlns:mavvm="clr-namespace:mavvm;assembly=mavvm"
    Shell.FlyoutBehavior="Disabled"
    x:Class="mavvmApp.AppShell">
    
    <ShellItem>
            <mavvm:MavvmShellContent ViewModel="{x:Type viewmodels:MainPageViewModel}">
            </mavvm:MavvmShellContent>
    </ShellItem>
    <TabBar>
        <Tab Title="Second">
            <mavvm:MavvmShellContent ViewModel="{x:Type viewmodels:SecondPageViewModel}">
            </mavvm:MavvmShellContent>
        </Tab>
        <Tab Title="Second 2">
            <mavvm:MavvmShellContent ViewModel="{x:Type viewmodels:SecondTabPageViewModel}">
            </mavvm:MavvmShellContent>
        </Tab>
    </TabBar>
</Shell>
```

</td>
 </tr>
</table>


<table>
 <tr>
    <td style="text-align: center"><b style="font-size:20px">Old</b> (MauiProgram.cs)</td>
    <td style="text-align: center"><b style="font-size:20px">New</b> (MauiProgram.cs)</td>
 </tr>
 <tr>
    <td>

```
public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

            // Add services
            builder.Services.AddSingleton<IConsoleService, ConsoleService>();
		
            return builder.Build();
        }
    }
```

</td>
    <td>

```
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
	    var builder = MauiApp.CreateBuilder();
	    builder
	    .UseMauiApp<App>()
	    .ConfigureFonts(fonts =>
	    {
	    	fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
	    })
	    .AddRoute<MainPage, MainPageViewModel>()
	    .AddRoute<SecondPage, SecondPageViewModel>()
	    .AddRoute<SecondTabPage, SecondTabPageViewModel>();
	    
	    // Add services
	    builder.Services.AddSingleton<IConsoleService, ConsoleService>();
	    
	    return builder.BuildWithContainer();
	}
}
```

</td>
 </tr>
</table>


## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

[MIT](https://choosealicense.com/licenses/mit/)
