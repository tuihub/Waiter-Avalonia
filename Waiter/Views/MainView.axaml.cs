using Avalonia.Controls;
using FluentAvalonia.UI.Controls;
using System;
using Waiter.Contracts;
using Waiter.ViewModels;

namespace Waiter.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }
    private void NavigationView_ItemInvoked(object? sender, NavigationViewItemInvokedEventArgs e)
    {
        if (e.InvokedItemContainer is NavigationViewItem nvi)
        {
            if (nvi.Tag is Type type)
            {
                var vm = this.DataContext as MainViewModel;
                vm.FrameViewNavigateFromObject(FrameView, type);
            }
        }
    }
}
