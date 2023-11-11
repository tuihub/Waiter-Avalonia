using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Models
{
    public class AppPackageSetting : ReactiveObject
    {
        private long _appPackageId;
        public long AppPackageId
        {
            get => _appPackageId;
            set => this.RaiseAndSetIfChanged(ref _appPackageId, value);
        }
        private string _appPath = string.Empty;
        public string AppPath
        {
            get => _appPath;
            set => this.RaiseAndSetIfChanged(ref _appPath, value);
        }
        private string _appBaseDir = string.Empty;
        public string AppBaseDir
        {
            get => _appBaseDir;
            set => this.RaiseAndSetIfChanged(ref _appBaseDir, value);
        }
        private string _appWorkDir = string.Empty;
        public string AppWorkDir
        {
            get => _appWorkDir;
            set => this.RaiseAndSetIfChanged(ref _appWorkDir, value);
        }
        private string _procMonName = string.Empty;
        public string ProcMonName
        {
            get => _procMonName;
            set => this.RaiseAndSetIfChanged(ref _procMonName, value);
        }
        private string _procMonPath = string.Empty;
        public string ProcMonPath
        {
            get => _procMonPath;
            set => this.RaiseAndSetIfChanged(ref _procMonPath, value);
        }
        private string _useProcListenMode = "False";
        public string UseProcListenMode
        {
            get => _useProcListenMode;
            set => this.RaiseAndSetIfChanged(ref _useProcListenMode, value);
        }
        private string _useShellExecute = "False";
        public string UseShellExecute
        {
            get => _useShellExecute;
            set => this.RaiseAndSetIfChanged(ref _useShellExecute, value);
        }
        public AppPackageSetting(long appPackageId, Db.AppPackageSetting? appPackageSetting)
        {
            AppPackageId = appPackageId;
            if (appPackageSetting != null)
            {
                AppPath = appPackageSetting.AppPath;
                AppBaseDir = appPackageSetting.AppBaseDir;
                AppWorkDir = appPackageSetting.AppWorkDir;
                ProcMonName = appPackageSetting.ProcMonName;
                ProcMonPath = appPackageSetting.ProcMonPath;
                UseProcListenMode = appPackageSetting.UseProcListenMode.ToString();
                UseShellExecute = appPackageSetting.UseShellExecute.ToString();
            }
        }
        public AppPackageSetting() { }
    }
}
