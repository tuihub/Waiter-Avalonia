using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Authentication.ExtendedProtection;
using Waiter.Contracts;
using Waiter.Core.Contracts.Services;
using Waiter.Pages;
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
                DataContext = ServiceProvider.GetRequiredService(typeof(MainViewModel))
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView()
            {
                DataContext = ServiceProvider.GetRequiredService(typeof(MainViewModel))
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

        // add singleton services
        services.AddSingleton<IPageService, PageService>();
        services.AddSingleton<ILibrarianClientService, ILibrarianClientService>();

        // add main view and view model
        services.AddScoped<MainView>();
        services.AddScoped<MainViewModel>();
        
        // add pages and view models
        services.AddScoped<HomePage>();
        services.AddScoped<HomePageViewModel>();
        services.AddScoped<SettingsPage>();
        services.AddScoped<SettingsPageViewModel>();
        services.AddScoped<UserPage>();
        services.AddScoped<UserPageViewModel>();

        return services;
    }
}
