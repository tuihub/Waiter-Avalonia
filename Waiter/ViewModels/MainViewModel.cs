﻿using Avalonia.Controls;
using FluentAvalonia.UI.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using Waiter.Contracts;
using Waiter.Pages;

namespace Waiter.ViewModels;

public class MainViewModel : ViewModelBase
{
    private IPageService _pageService;
    public MainViewModel(IPageService pageService)
    {
        _pageService = pageService;
    }
    public IList<NavigationViewItem> MenuItems { get; } = new List<NavigationViewItem>
    {
        new NavigationViewItem
        {
            Content = "主界面",
            Tag = typeof(HomePage),
            IconSource = new SymbolIconSource { Symbol = Symbol.Home }
        },
        new NavigationViewItem
        {
            Content = "Apps",
            Tag = typeof(AppsPage),
            IconSource = new SymbolIconSource { Symbol = Symbol.AllApps }
        }
    };
    public IList<NavigationViewItem> FooterMenuItems { get; } = new List<NavigationViewItem>
    {
        new NavigationViewItem
        {
            Content = "用户",
            Tag = typeof(UserPage),
            IconSource = new SymbolIconSource { Symbol = Symbol.People }
        },
        new NavigationViewItem
        {
            Content = "设置",
            Tag = typeof(SettingsPage),
            IconSource = new SymbolIconSource { Symbol = Symbol.Setting }
        }
    };
    private NavigationViewItem? _selectedItem;
    public NavigationViewItem? SelectedItem
    {
        get => _selectedItem;
        set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
    }

    public void FrameViewNavigateFromObject(Frame frame, Type type)
    {
        frame.Content?.GetType().GetMethod("OnNavigatedFrom")?.Invoke(frame.Content, null);
        frame.Content = _pageService.GetPage(type);
        frame.Content?.GetType().GetMethod("OnNavigatedTo")?.Invoke(frame.Content, null);
    }
}
