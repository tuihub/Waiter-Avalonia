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
        public async Task<(string, string)> GetTokenAsync(string username, string password)
        {
            var client = _grpcClientFactory.CreateClient<LibrarianSephirahServiceClient>("SephirahClient");
            var request = new GetTokenRequest
            {
                Username = username,
                Password = password
            };
            var response = await client.GetTokenAsync(request);
            return (response.AccessToken, response.RefreshToken);
        }

        public async Task<(string, string)> GetTokenAsync()
        {
            throw new NotImplementedException();
        }
    }
}
