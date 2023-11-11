using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Models.Db
{
    public class User
    {
        public long Id { get; set; }
        [MaxLength(512)]
        public string AccessToken { get; set; } = string.Empty;
        [MaxLength(512)]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
