using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Contracts
{
    public interface IDialogService
    {
        Task ShowContentDialogAsync(Exception ex);
        Task ShowContentDialogAsync(string msg);
        Task ShowLoginDialogAsync();
    }
}
