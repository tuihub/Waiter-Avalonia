using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;
using TuiHub.Protos.Librarian.V1;

namespace Waiter.Core.Contracts.Services
{
    public partial interface ILibrarianClientService
    {
        Task<GetPurchasedAppsResponse> GetPurchasedAppsAsync(AppSource? source = null, CancellationToken cts = default);
        Task<ListAppCategoriesResponse> ListAppCategoriesAsync(CancellationToken cts = default);
    }
}
