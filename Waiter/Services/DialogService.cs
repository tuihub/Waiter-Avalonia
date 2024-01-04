using FluentAvalonia.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Contracts;
using Waiter.Core.Contracts.Services;
using Waiter.ViewModels.Dialogs;
using Waiter.Views.Dialogs;

namespace Waiter.Services
{
    public class DialogService : IDialogService
    {
        private ILibrarianClientService _librarianClientService;
        private IStateService _stateService;
        public DialogService(ILibrarianClientService librarianClientService, IStateService stateService)
        {
            _librarianClientService = librarianClientService;
            _stateService = stateService;
        }

        public Task ShowContentDialogAsync(Exception ex)
        {
            var dialog = new ContentDialog
            {
                Title = "错误",
                Content = "发生了一个错误，错误信息：\n" + ex.Message,
                CloseButtonText = "关闭"
            };
            return dialog.ShowAsync();
        }

        public Task ShowContentDialogAsync(string msg)
        {
            var dialog = new ContentDialog
            {
                Title = "信息",
                Content = msg,
                CloseButtonText = "关闭"
            };
            return dialog.ShowAsync();
        }

        public async Task ShowLoginDialogAsync()
        {
            var dialog = new ContentDialog
            {
                Title = "登录",
                PrimaryButtonText = "登录",
                CloseButtonText = "取消"
            };
            var loginDialogViewModel = new LoginDialogViewModel(dialog);
            dialog.Content = new LoginDialog
            {
                DataContext = loginDialogViewModel
            };
            var dialogResult = await dialog.ShowAsync();
            if (dialogResult == ContentDialogResult.Primary)
            {
                var userName = loginDialogViewModel.UserName;
                var password = loginDialogViewModel.Password;
                try
                {
                    (var accessToken, var refreshToken) = await _librarianClientService.GetTokenAsync(userName, password);
                    if (accessToken != null && refreshToken != null)
                    {
                        _stateService.CurrentState = IStateService.State.LoggedIn;
                        _stateService.AccessToken = accessToken;
                        _stateService.RefreshToken = refreshToken;
                        await ShowContentDialogAsync("登录成功");
                    }
                    else
                    {
                        await ShowContentDialogAsync("登录失败");
                    }
                }
                catch (Exception ex)
                {
                    await ShowContentDialogAsync(ex);
                }
            }
            else
            {
                await ShowContentDialogAsync("用户取消登录");
            }
        }
    }
}
