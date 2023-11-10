using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Services
{
    public class PageService : IPageService
    {
        private IServiceProvider _serviceProvider;

        public PageService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        T? IPageService.GetPage<T>() where T : class
        {
            if (typeof(Control).IsAssignableFrom(typeof(T)) == false)
                throw new InvalidOperationException("The page must be a Control");

            return (T?)_serviceProvider.GetService(typeof(T));
        }

        Control? IPageService.GetPage(Type pageType)
        {
            if (typeof(Control).IsAssignableFrom(pageType) == false)
                throw new InvalidOperationException("The page must be a Control");

            return _serviceProvider.GetService(pageType) as Control;
        }
    }
}
