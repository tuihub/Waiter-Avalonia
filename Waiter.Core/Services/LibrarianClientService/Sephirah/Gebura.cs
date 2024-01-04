using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;
using TuiHub.Protos.Librarian.V1;
using Waiter.Core.Contracts.Services;

using static TuiHub.Protos.Librarian.Sephirah.V1.LibrarianSephirahService;

namespace Waiter.Core.Services
{
    public partial class LibrarianClientService : ILibrarianClientService
    {
        public async Task<GetPurchasedAppsResponse> GetPurchasedAppsAsync(AppSource? source = null, CancellationToken cts = default)
        {
            var client = _grpcClientFactory.CreateClient<LibrarianSephirahServiceClient>("SephirahClientWithAccessToken");
            var request = new GetPurchasedAppsRequest();
            if (source != null)
                request.Source = (AppSource)source;
            return await client.GetPurchasedAppsAsync(request, cancellationToken: cts);
        }

        public async Task<ListAppCategoriesResponse> ListAppCategoriesAsync(CancellationToken cts = default)
        {
            var client = _grpcClientFactory.CreateClient<LibrarianSephirahServiceClient>("SephirahClientWithAccessToken");
            var request = new ListAppCategoriesRequest();
            return await client.ListAppCategoriesAsync(request, cancellationToken: cts);
        }
    }
}
