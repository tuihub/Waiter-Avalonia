using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Core.Contracts.Services;
using Waiter.Models;

namespace Waiter.ViewModels
{
    public class AppsPageViewModel : ViewModelBase
    {
        private ILibrarianClientService _librarianClientService;

        public AppsPageViewModel(ILibrarianClientService librarianClientService)
        {
            _librarianClientService = librarianClientService;
        }
        public string Greeting => "AppsPage Hello World!";
    }
}
