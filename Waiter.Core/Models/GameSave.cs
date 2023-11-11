using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;

namespace Waiter.Core.Models
{
    public class GameSave
    {
        public long InternalId { get; set; }
        public string Name { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public byte[] Sha256 { get; set; } = new byte[32];
        public DateTime CreateTime { get; set; }
        public bool IsPinned { get; set; }

        public GameSave(ListGameSaveFilesResponse.Types.Result result)
        {
            InternalId = result.File.Id.Id;
            Name = result.File.Name;
            SizeBytes = result.File.SizeBytes;
            Sha256 = result.File.Sha256.ToArray();
            CreateTime = result.File.CreateTime.ToDateTime();
            IsPinned = result.Pinned;
        }

        public override string ToString()
        {
            return $"{{ InternalId = {InternalId}, Name = {Name}, SizeBytes = {SizeBytes}, " +
                   $"Sha256 = {BitConverter.ToString(Sha256).Replace("-", "")}, " +
                   $"CreateTime = {CreateTime:O}, IsPinned = {IsPinned} }}";
        }
    }
}
