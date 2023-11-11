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
    public class GlobalContext
    {
        public GlobalContext()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(AssemblyDir)
                          .AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            SystemConfig = configuration.GetSection("SystemConfig").Get<SystemConfig>();

            // ensure data, cache dir created
            Directory.CreateDirectory(SystemConfig.GetRealDataDirPath());
            Directory.CreateDirectory(SystemConfig.GetRealCacheDirPath());
        }
        public readonly string AssemblyDir = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);
        public SystemConfig SystemConfig { get; set; } = new SystemConfig();
        public UserConfig UserConfig { get; set; } = new UserConfig();
    }
}
