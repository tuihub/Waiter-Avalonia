using Avalonia.Controls;
using Waiter.ViewModels;

namespace Waiter.Pages
{
    public partial class AppsPage : UserControl
    {
        public AppsPage(AppsPageViewModel appsPageViewModel)
        {
            DataContext = appsPageViewModel;

            InitializeComponent();
        }
        public AppsPage()
        {
            InitializeComponent();
        }

        public void OnNavigatedTo()
        {
            (DataContext as AppsPageViewModel)?.OnNavigatedToAsync();
        }
    }
}
