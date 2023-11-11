using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Waiter.Core.Contracts.Services;
using Waiter.Core.Services;
using Waiter.Models;

namespace Waiter.Models
{
    public static class GlobalContext
    {
        public static readonly string AssemblyDir = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);
        public static SystemConfig SystemConfig { get; set; } = new SystemConfig();
        public static UserConfig UserConfig { get; set; } = new UserConfig();
    }
}
