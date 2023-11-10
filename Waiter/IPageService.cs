using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter
{
    public interface IPageService
    {
        T? GetPage<T>() where T : class;
        Control? GetPage(Type pageType);
    }
}
