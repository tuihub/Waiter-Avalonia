﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Core.Contracts.Services;

namespace Waiter.Core.Services
{
    public partial class LibrarianClientService : ILibrarianClientService
    {
        public Task<(string, string)> GetTokenAsync(string username, string password)
        {
            var request = new GetTokenRequest
            {
                Username = username,
                Password = password
            };
            var response = await client.GetTokenAsync(request);
            return (response.AccessToken, response.RefreshToken);
        }

        public Task<(string, string)> GetTokenAsync()
        {
            throw new NotImplementedException();
        }
    }
}