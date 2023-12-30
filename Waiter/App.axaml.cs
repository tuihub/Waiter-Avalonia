using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Security.Authentication.ExtendedProtection;
using Waiter.Contracts;
using Waiter.Core.Contracts.Services;
using Waiter.Models.Db;
using Waiter.Models;
using Waiter.Pages;
using Waiter.Services;
using Waiter.ViewModels;
using Waiter.Views;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Waiter.Helpers;
using Waiter.Core.Services;

using static TuiHub.Protos.Librarian.Sephirah.V1.LibrarianSephirahService;
using System.Diagnostics;
using Avalonia.Controls;

namespace Waiter;

public partial class App : Application
{
    public IServiceProvider ServiceProvider = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        PreConfiguration();
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

    private void ConfigureServiceProvider()
    {
        var services = ConfigureServices();
        ServiceProvider = services.BuildServiceProvider();
    }

    private static ServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();

        // add db context
        services.AddDbContext<ApplicationDbContext>();

        // add grpc client factory
        ConfigureGrpcClientFactory(services);

        // add singleton services
        services.AddSingleton<IStateService, StateService>();
        services.AddSingleton<IPageService, PageService>();
        services.AddSingleton<ILibrarianClientService, LibrarianClientService>();

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
        services.AddScoped<AppsPage>();
        services.AddScoped<AppsPageViewModel>();

        return services;
    }

    private static void ConfigureGrpcClientFactory(ServiceCollection services)
    {
        services.AddGrpcClient<LibrarianSephirahServiceClient>("SephirahClient", o =>
        {
            o.Address = new Uri(GlobalContext.SystemConfig.ServerURL);
        });
        services.AddGrpcClient<LibrarianSephirahServiceClient>("SephirahClientWithAccessToken", o =>
        {
            o.Address = new Uri(GlobalContext.SystemConfig.ServerURL);
        })
        .AddCallCredentials((context, metadata, serviceProvider) =>
        {
            var provider = serviceProvider.GetRequiredService<IStateService>();
            var token = provider.AccessToken;
            metadata.Add("Authorization", $"Bearer {token}");
            return Task.CompletedTask;
        });
        services.AddGrpcClient<LibrarianSephirahServiceClient>("SephirahClientWithRefreshToken", o =>
        {
            o.Address = new Uri(GlobalContext.SystemConfig.ServerURL);
        })
        .AddCallCredentials((context, metadata, serviceProvider) =>
        {
            var provider = serviceProvider.GetRequiredService<IStateService>();
            var token = provider.RefreshToken;
            metadata.Add("Authorization", $"Bearer {token}");
            return Task.CompletedTask;
        });
    }

    private void PreConfiguration()
    {
        // do not configure in design mode
        if (Design.IsDesignMode) return;
        var builder = new ConfigurationBuilder()
                          .SetBasePath(GlobalContext.AssemblyDir)
                          .AddJsonFile("appsettings.json", optional: false);
        var configuration = builder.Build();
        GlobalContext.SystemConfig = configuration.GetSection("SystemConfig").Get<SystemConfig>();

        // ensure data, cache dir created
        Directory.CreateDirectory(GlobalContext.SystemConfig.GetRealDataDirPath());
        Directory.CreateDirectory(GlobalContext.SystemConfig.GetRealCacheDirPath());

        // ensure db created
        using var db = new ApplicationDbContext();
        db.Database.Migrate();

        // ensure user created
        if (db.Users.Any() == false)
            db.Users.Add(new User());
        db.SaveChanges();

        // set login state from db
        var user = db.Users.First();
        GlobalContextStateHelper.UpdateLoginState(
                                    db,
                                    string.IsNullOrEmpty(user.AccessToken) ? null : user.AccessToken,
                                    string.IsNullOrEmpty(user.RefreshToken) ? null : user.RefreshToken)
                                .Wait();
    }
}
