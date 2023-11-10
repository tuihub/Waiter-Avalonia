using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Authentication.ExtendedProtection;
using Waiter.Services;
using Waiter.ViewModels;
using Waiter.Views;

namespace Waiter;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        ConfigureServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static void ConfigureServiceProvider()
    {
        var services = ConfigureServices();
        ServiceProvider = services.BuildServiceProvider();
    }

    private static ServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IPageService, PageService>();

        return services;
    }
}
