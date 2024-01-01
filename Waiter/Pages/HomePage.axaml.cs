using Avalonia.Controls;
using Waiter.ViewModels;

namespace Waiter.Pages
{
    public partial class HomePage : UserControl
    {
        public HomePage(HomePageViewModel homePageViewModel)
        {
            DataContext = homePageViewModel;

            InitializeComponent();
        }

        public HomePage()
        {
            InitializeComponent();
        }

        public void OnNavigatedTo()
        {
            (DataContext as HomePageViewModel)?.OnNavigatedTo();
        }
    }
}
