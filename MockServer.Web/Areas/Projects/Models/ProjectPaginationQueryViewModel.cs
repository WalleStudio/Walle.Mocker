using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockServer.Web.Areas.Projects.Models
{
    public class ProjectPaginationQueryViewModel
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPage { get; set; } = 0;
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; } = 0;
        /// <summary>
        /// 全部，已拥有，已加入，未加入
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;
    }
}