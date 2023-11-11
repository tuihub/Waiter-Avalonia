using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Core.Models
{
    public class AppDetails
    {
        public string? Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Developer { get; set; }
        public string? Publisher { get; set; }
        public string? Version { get; set; }
        public AppDetails(TuiHub.Protos.Librarian.V1.AppDetails appDetails)
        {
            DateTime? releaseDate;
            if (DateTime.TryParse(appDetails.ReleaseDate, out DateTime tmpDT) == true)
                releaseDate = tmpDT;
            else
                releaseDate = null;
            Description = string.IsNullOrEmpty(appDetails.Description) ? null : appDetails.Description;
            ReleaseDate = releaseDate;
            Developer = string.IsNullOrEmpty(appDetails.Developer) ? null : appDetails.Developer;
            Publisher = string.IsNullOrEmpty(appDetails.Publisher) ? null : appDetails.Publisher;
            Version = string.IsNullOrEmpty(appDetails.Version) ? null : appDetails.Version;
        }
        public AppDetails() { }
    }
}
