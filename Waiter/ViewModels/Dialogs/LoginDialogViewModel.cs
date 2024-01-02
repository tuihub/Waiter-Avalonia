using FluentAvalonia.UI.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Core.Contracts.Services;
using Waiter.Models;

namespace Waiter.ViewModels.Dialogs
{
    public class LoginDialogViewModel : ViewModelBase
    {
        private ContentDialog _dialog;
        public LoginDialogViewModel(ContentDialog dialog)
        {
            _dialog = dialog;
        }
        private string _userName = string.Empty;
        public string UserName
        {
            get => _userName;
            set => this.RaiseAndSetIfChanged(ref _userName, value);
        }
        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }
    }
}
