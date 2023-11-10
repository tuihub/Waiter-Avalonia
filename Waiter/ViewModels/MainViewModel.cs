using Avalonia.Controls;
using FluentAvalonia.UI.Controls;
using System;
using System.Collections.Generic;
using Waiter.Pages;

namespace Waiter.ViewModels;

public class MainViewModel : ViewModelBase
{
    public NavigationFactory NavigationFactory { get; }

    public MainViewModel()
    {
        NavigationFactory = new NavigationFactory(this);
    }

    public IList<NavigationViewItem> MenuItems { get; } = new List<NavigationViewItem>
    {
        new NavigationViewItem
        {
            Content = "主界面",
            Tag = typeof(HomePageViewModel),
            IconSource = new SymbolIconSource { Symbol = Symbol.Home }
        }
    };
    public IList<NavigationViewItem> FooterMenuItems { get; } = new List<NavigationViewItem>
    {
        new NavigationViewItem
        {
            Content = "设置",
            Tag = typeof(SettingsPageViewModel),
            IconSource = new SymbolIconSource { Symbol = Symbol.Setting }
        }
    };
}

public class NavigationFactory : INavigationPageFactory
{
    public NavigationFactory(MainViewModel owner)
    {
        Owner = owner;
    }

    public MainViewModel Owner { get; }

    public Control GetPage(Type srcType)
    {
        return null;
    }

    public Control GetPageFromObject(object target)
    {
        if (target is HomePageViewModel)
        {
            return new HomePage
            {
                DataContext = target
            };
        }
        else if (target is SettingsPageViewModel)
        {
            return new SettingsPage
            {
                DataContext = target
            };
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}
