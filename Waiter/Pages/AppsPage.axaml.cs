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
    }
}
