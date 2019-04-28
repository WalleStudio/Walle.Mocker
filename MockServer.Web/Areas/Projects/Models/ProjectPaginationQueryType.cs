using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockServer.Web.Areas.Projects.Models
{
    public class ProjectPaginationQueryType
    {
        /// <summary>
        /// 已加入
        /// </summary>
        public const string Joined = "Joined";
        /// <summary>
        /// 未加入
        /// </summary>
        public const string UnJoined = "UnJoined";
        /// <summary>
        /// 待审核的
        /// </summary>
        public const string AuditProject = "AuditProject";
        /// <summary>
        /// 部门待申请加入的
        /// </summary>
        public const string DepartmentApply = "DepartmentApply";
    }
}