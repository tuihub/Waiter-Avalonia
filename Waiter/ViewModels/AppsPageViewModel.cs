using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Contracts;
using Waiter.Core.Contracts.Services;
using Waiter.Models;

namespace Waiter.ViewModels
{
    public class AppsPageViewModel : ViewModelBase
    {
        private ILibrarianClientService _librarianClientService;
        private IRequestService _requestService;
        private IDialogService _dialogService;

        public AppsPageViewModel(ILibrarianClientService librarianClientService, IRequestService requestService, IDialogService dialogService)
        {
            _librarianClientService = librarianClientService;
            _requestService = requestService;
            _dialogService = dialogService;
        }

        private List<AppCategoryWithApps> _appCategoriesWithApps = new();
        public List<AppCategoryWithApps> AppCategoriesWithApps
        {
            get => _appCategoriesWithApps;
            set => this.RaiseAndSetIfChanged(ref _appCategoriesWithApps, value);
        }
        private List<Core.Models.App> _apps = new();
        public List<Core.Models.App> Apps
        {
            get => _apps;
            set => this.RaiseAndSetIfChanged(ref _apps, value);
        }
        private List<Core.Models.AppCategory> _appCategories = new();
        public List<Core.Models.AppCategory> AppCategories
        {
            get => _appCategories;
            set => this.RaiseAndSetIfChanged(ref _appCategories, value);
        }


        public async void OnNavigatedToAsync()
        {
            try
            {
                await _requestService.DoRequestAsync(async () =>
                {
                    Apps = (await _librarianClientService.GetPurchasedAppsAsync())
                           .Apps
                           .Select(x => new Core.Models.App(x))
                           .ToList();
                    AppCategories = (await _librarianClientService.ListAppCategoriesAsync())
                                    .AppCategories
                                    .Select(x => new Core.Models.AppCategory(x))
                                    .ToList();
                });
                var appCategoriesWithApps = AppCategories
                                        .Select(x => new AppCategoryWithApps
                                        {
                                            AppCategory = x,
                                            Apps = Apps.Where(y => x.AppIds.Contains(y.InternalId)).ToList()
                                        })
                                        .ToList();
                appCategoriesWithApps.Add(new AppCategoryWithApps
                {
                    AppCategory = null,
                    Apps = Apps.Where(x => !AppCategories.SelectMany(x => x.AppIds).Contains(x.InternalId)).ToList()
                });
                AppCategoriesWithApps = appCategoriesWithApps;
            }
            catch (Exception ex)
            {
                await _dialogService.ShowContentDialogAsync(ex);
            }
        }
    }
}
