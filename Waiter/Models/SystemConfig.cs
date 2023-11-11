using System.IO;

namespace Waiter.Models
{
    public class SystemConfig
    {
        public string ServerURL { get; set; } = string.Empty;
        // relative to app assembly dir
        public string DataDirPath { get; set; } = string.Empty;
        // relative to DataDirPath
        public string SqliteDbPath { get; set; } = string.Empty;
        // relative to DataDirPath
        public string CacheDirPath { get; set; } = string.Empty;
        public int FileTransferChunkBytes { get; set; } = 32768;
        public string GetRealDataDirPath()
        {
            return Path.Combine(GlobalContext.AssemblyDir, DataDirPath);
        }
        public string GetRealSqliteDbPath()
        {
            return Path.Combine(GlobalContext.AssemblyDir, DataDirPath, SqliteDbPath);
        }
        public string GetRealCacheDirPath()
        {
            return Path.Combine(GlobalContext.AssemblyDir, DataDirPath, CacheDirPath);
        }
    }
}
