using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.V1;

namespace Waiter.Core.Models
{
    public class AppPackage
    {
        public long InternalId { get; set; }
        public AppPackageSource Source { get; set; }
        public long SourceAppId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public AppPackageBinary? AppPackageBinary { get; set; }
        public bool IsPublic { get; set; }
        public AppPackage(TuiHub.Protos.Librarian.V1.AppPackage appPackage)
        {
            InternalId = appPackage.Id.Id;
            Source = appPackage.Source;
            SourceAppId = appPackage.SourceId.Id;
            Name = appPackage.Name;
            Description = appPackage.Description;
            AppPackageBinary = new AppPackageBinary(appPackage.Id.Id ,appPackage.Binary);
            IsPublic = appPackage.Public;
        }
        public AppPackage() { }
        public override string ToString()
        {
            return $"[{InternalId}]{Name}";
        }
    }
}
