using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockServer.Web.Areas.Projects.Models
{
    public class ProjectPaginationQueryResultViewModel
    {

        public int TotalCount { get; set; } = 0;
        public List<Detail> DetailInfo { get; set; } = null;

        public class Detail
        {
            #region 构造函数
            public Detail()
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
                ApplyDialogVisible = false;
                IsApply = false;
                EditDialogVisible = false;
                AuditDialogVisible = false;
                IsCanEdit = false;
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

            public string CreateTimeStr
            {
                get
                {
                    return CreateTime.ToString();
                }
            }

            /// <summary>
            /// 申请的对话框有效性
            /// </summary>
            public bool ApplyDialogVisible { get; set; }

            /// <summary>
            /// 是否已申请
            /// </summary>
            public bool IsApply { get; set; }

            /// <summary>
            /// 编辑的对话框有效性
            /// </summary>
            public bool EditDialogVisible { get; set; }

            /// <summary>
            /// 审核的对话框有效性
            /// </summary>
            public bool AuditDialogVisible { get; set; }

            /// <summary>
            /// 是否可以编辑
            /// </summary>
            public bool IsCanEdit { get; set; }
        }
    }
}