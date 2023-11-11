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
        // username password login
        Task<(string, string)> GetTokenAsync(string username, string password);
        // refreshToken reAuth
        Task<(string, string)> GetTokenAsync();
    }
}
