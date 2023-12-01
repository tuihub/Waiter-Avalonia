using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Models;

namespace Waiter.ViewModels.Design
{
    public class AppsPageViewModel : ViewModelBase
    {
        private List<AppCategoryWithApps> _appCategoriesWithApps =
        [
            new() {
                AppCategory = new Core.Models.AppCategory
                {
                    InternalId = 1,
                    Name = "Category 1"
                },
                Apps =
                [
                    new Core.Models.App
                    {
                        InternalId = 1,
                        Name = "App 1",
                        IconImageUrl = "https://www.baidu.com/favicon.ico",
                    },
                    new Core.Models.App
                    {
                        InternalId = 2,
                        Name = "App 2",
                    },
                    new Core.Models.App
                    {
                        InternalId = 3,
                        Name = "App 3",
                    },
                ]
            },
            new() {
                AppCategory = new Core.Models.AppCategory
                {
                    InternalId = 2,
                    Name = "Category 2"
                },
                Apps =
                [
                    new Core.Models.App
                    {
                        InternalId = 4,
                        Name = "App 4",
                    },
                    new Core.Models.App
                    {
                        InternalId = 5,
                        Name = "App 5",
                    },
                    new Core.Models.App
                    {
                        InternalId = 6,
                        Name = "App 6",
                    },
                    new Core.Models.App
                    {
                        InternalId = 7,
                        Name = "App 7",
                    },
                ]
            },
            new() {
                AppCategory = null,
                Apps =
                [
                    new Core.Models.App
                    {
                        InternalId = 8,
                        Name = "App 8",
                    },
                    new Core.Models.App
                    {
                        InternalId = 9,
                        Name = "App 9",
                    },

                ]
            },
        ];
        public List<AppCategoryWithApps> AppCategoriesWithApps
        {
            get => _appCategoriesWithApps;
        }
        private List<string> _appNames = new()
        {
            "App1",
            "App2",
            "App3",
        };
        public List<string> AppNames
        {
            get => _appNames;
        }
    }
}
