using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Models.Db
{
    [Index(nameof(AppPackageId))]
    public class AppPackageSetting
    {
        public long Id { get; set; }
        public long AppPackageId { get; set; }
        [MaxLength(256)]
        public string AppPath { get; set; } = string.Empty;
        [MaxLength(256)]
        public string AppBaseDir { get; set; } = string.Empty;
        [MaxLength(256)]
        public string AppWorkDir { get; set; } = string.Empty;
        [MaxLength(256)]
        public string ProcMonName { get; set; } = string.Empty;
        [MaxLength(256)]
        public string ProcMonPath { get; set; } = string.Empty;
        public bool UseProcListenMode { get; set; } = false;
        public bool UseShellExecute { get; set; } = false;
        public AppPackageSetting(Models.AppPackageSetting appPackageSetting)
        {
            AppPackageId = appPackageSetting.AppPackageId;
            AppPath = appPackageSetting.AppPath;
            AppBaseDir = appPackageSetting.AppBaseDir;
            AppWorkDir = appPackageSetting.AppWorkDir;
            ProcMonName = appPackageSetting.ProcMonName;
            ProcMonPath = appPackageSetting.ProcMonPath;
            UseProcListenMode = bool.Parse(appPackageSetting.UseProcListenMode);
            UseShellExecute = bool.Parse(appPackageSetting.UseShellExecute);
        }
        public AppPackageSetting() { }

        public static void UpdateFromViewModelAppPackageSetting(ref AppPackageSetting e, Models.AppPackageSetting appPackageSetting)
        {
            e.AppPackageId = appPackageSetting.AppPackageId;
            e.AppPath = appPackageSetting.AppPath;
            e.AppBaseDir = appPackageSetting.AppBaseDir;
            e.AppWorkDir = appPackageSetting.AppWorkDir;
            e.ProcMonName = appPackageSetting.ProcMonName;
            e.ProcMonPath = appPackageSetting.ProcMonPath;
            e.UseProcListenMode = bool.Parse(appPackageSetting.UseProcListenMode);
            e.UseShellExecute = bool.Parse(appPackageSetting.UseShellExecute);
        }
    }
}
