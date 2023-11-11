using Grpc.Net.ClientFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Core.Contracts.Services;

namespace Waiter.Core.Services
{
    public partial class LibrarianClientService : ILibrarianClientService
    {
        GrpcClientFactory _grpcClientFactory;
        public LibrarianClientService(GrpcClientFactory grpcClientFactory)
        {
            _grpcClientFactory = grpcClientFactory;
        }
    }
}
