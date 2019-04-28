using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockServer.Web.Areas.Projects.Models
{
    public class ProjectQueryDetailResultViewModel
    {
        #region 构造函数
        public ProjectQueryDetailResultViewModel()
        {
            Id = 0;
            Name = string.Empty;
            Creator = string.Empty;
            Owner = string.Empty;
            SkyEye = string.Empty;
            State = string.Empty;
            CreateTime = new DateTime(1900, 1, 1);
            Url = string.Empty;
            Description = string.Empty;
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
                return CreateTime.ToString("yyyy-MM-dd HH:mm");
            }
        }
    }
}