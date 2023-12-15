using ReactiveUI;
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

        private List<AppCategoryWithApps> _appCategoriesWithApps = new();
        public List<AppCategoryWithApps> AppCategoriesWithApps
        {
            get => _appCategoriesWithApps;
            set => this.RaiseAndSetIfChanged(ref _appCategoriesWithApps, value);
        }
        private List<string> _appNames = new();
        public List<string> AppNames
        {
            get => _appNames;
            set => this.RaiseAndSetIfChanged(ref _appNames, value);
        }
    }
}
