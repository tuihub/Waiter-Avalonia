using FluentAvalonia.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Contracts;

namespace Waiter.Services
{
    public class DialogService : IDialogService
    {
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
    }
}
