using Avalonia.Controls;
using FluentAvalonia.UI.Controls;
using System;
using Waiter.Pages;

namespace Waiter.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        NavigationFactory = new NavigationFactory(this);
    }

    public NavigationFactory NavigationFactory { get; }
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
