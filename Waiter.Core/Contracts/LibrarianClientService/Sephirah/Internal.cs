using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;

namespace Waiter.Core.Contracts.Services
{
    public partial interface ILibrarianClientService
    {
        Task<GetServerInformationResponse> GetServerInformationAsync(CancellationToken cts = default);
    }
}
