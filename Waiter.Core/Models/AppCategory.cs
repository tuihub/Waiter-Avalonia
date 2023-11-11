using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Core.Models
{
    public class AppCategory
    {
        public long InternalId { get; set; }
        public string Name { get; set; } = null!;
        public AppCategory() { }
        public AppCategory(TuiHub.Protos.Librarian.V1.AppCategory appCategory)
        {
            InternalId = appCategory.Id.Id;
            Name = appCategory.Name;
        }
    }
}
