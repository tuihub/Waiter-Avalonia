using Avalonia.Controls;
using Waiter.ViewModels;

namespace Waiter.Pages
{
    public partial class UserPage : UserControl
    {
        public UserPage(UserPageViewModel userPageViewModel)
        {
            DataContext = userPageViewModel;

            InitializeComponent();
        }
    }
}
