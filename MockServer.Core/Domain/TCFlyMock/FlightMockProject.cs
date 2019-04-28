using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCBase.Data;

namespace MockServer.Core.Domain.TCFlyMock
{
    public class FlightMockProject
    {
        #region 构造函数
        public FlightMockProject()
        {
            Id = 0;
            Name = string.Empty;
            Creator = string.Empty;
            Owner = string.Empty;
            SkyEye = string.Empty;
            State = string.Empty;
            CreateTime = DateTime.Now;
            Url = string.Empty;
            Description = string.Empty;
            IsPage = true;
            PageIndex = 0;
            PageSize = 0;
            IsApply = false;
            IsCanEdit = false;
            CurrentUser = string.Empty;
        }
        #endregion

        public long Id { get; set; }

        public string Name { get; set; }

        public string Creator { get; set; }

        public string Owner { get; set; }

        public string SkyEye { get; set; }

        public string State { get; set; }

        public DateTime CreateTime { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// 是否分页
        /// </summary>
        [Ignore]
        public bool IsPage { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        [Ignore]
        public int PageIndex { get; set; }

        /// <summary>
        /// 条数
        /// </summary>
        [Ignore]
        public int PageSize { get; set; }

        /// <summary>
        /// 是否已申请
        /// </summary>
        [Ignore]
        public bool IsApply { get; set; }

        /// <summary>
        /// 是否可以编辑
        /// </summary>
        [Ignore]
        public bool IsCanEdit { get; set; }

        /// <summary>
        /// 当前用户
        /// </summary>
        [Ignore]
        public string CurrentUser { get; set; }
    }
}
