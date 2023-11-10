using Avalonia.Controls;
using Waiter.ViewModels;

namespace Waiter.Pages
{
    public partial class SettingsPage : UserControl
    {
        public SettingsPage(SettingsPageViewModel settingsPageViewModel)
        {
            DataContext = settingsPageViewModel;

            InitializeComponent();
        }
    }
}
