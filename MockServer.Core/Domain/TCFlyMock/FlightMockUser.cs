using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Domain.TCFlyMock
{
    public class FlightMockUser
    {
        #region 构造函数
        public FlightMockUser()
        {
            Id = 0;
            UserId = 0;
            UserName = string.Empty;
            WorkId = string.Empty;
            DepartmentId = 0;
            Department = string.Empty;
            IsAdministrator = 0;
            CreateTime = DateTime.Now;
            LastUpdateTime = DateTime.Now;
        }
        #endregion

        public long Id { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string WorkId { get; set; }

        public int DepartmentId { get; set; }

        public string Department { get; set; }

        /// <summary>
        /// 是否是管理员（0-不是，1-是）
        /// </summary>
        public int IsAdministrator { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
