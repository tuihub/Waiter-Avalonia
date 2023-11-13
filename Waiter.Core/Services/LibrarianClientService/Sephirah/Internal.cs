using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Core.Contracts.Services;

using static TuiHub.Protos.Librarian.Sephirah.V1.LibrarianSephirahService;

namespace Waiter.Core.Services
{
    public partial class LibrarianClientService : ILibrarianClientService
    {
        public async Task<GetServerInformationResponse> GetServerInformationAsync()
        {
            var client = _grpcClientFactory.CreateClient<LibrarianSephirahServiceClient>("SephirahClient");
            return await client.GetServerInformationAsync(new GetServerInformationRequest());
        }
    }
}
