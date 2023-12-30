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
        public async Task<(string, string)> GetTokenAsync(string username, string password, CancellationToken cts = default)
        {
            var client = _grpcClientFactory.CreateClient<LibrarianSephirahServiceClient>("SephirahClient");
            var request = new GetTokenRequest
            {
                Username = username,
                Password = password
            };
            var response = await client.GetTokenAsync(request, cancellationToken: cts);
            if (cts.IsCancellationRequested)
                return (string.Empty, string.Empty);
            return (response.AccessToken, response.RefreshToken);
        }

        public async Task<(string, string)> RefreshTokenAsync(CancellationToken cts = default)
        {
            var client = _grpcClientFactory.CreateClient<LibrarianSephirahServiceClient>("SephirahClientWithRefreshToken");
            var request = new RefreshTokenRequest();
            var response = await client.RefreshTokenAsync(request, cancellationToken: cts);
            if (cts.IsCancellationRequested)
                return (string.Empty, string.Empty);
            return (response.AccessToken, response.RefreshToken);
        }
    }
}
