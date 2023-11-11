using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Models
{
    public class AppCategoryWithApps : ReactiveObject
    {
        private Core.Models.AppCategory? _appCategory;
        public Core.Models.AppCategory? AppCategory
        {
            get => _appCategory;
            set => this.RaiseAndSetIfChanged(ref _appCategory, value);
        }
        public List<Core.Models.App> _apps = new();
        public List<Core.Models.App> Apps
        {
            get => _apps;
            set => this.RaiseAndSetIfChanged(ref _apps, value);
        }
        public string AppCategoryName
        {
            get => AppCategory?.Name ?? "null";
        }
    }
}
