using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Domain
{
    public class LyOAuthUserInfo
    {
        public string UserName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string WorkId { get; set; } = string.Empty;

        public int UserId { get; set; } = 0;

        public int DepartmentId { get; set; } = 0;

        public long RoleId { get; set; } = 0;
    }
}
