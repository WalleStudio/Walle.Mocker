using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockServer.Web.Models
{
	/// <summary>
	/// 菜单视图
	/// </summary>
	public class MenuViewModel
	{
		/// <summary>
		/// 菜单1级模块
		/// </summary>
		public List<Module> Modules { get; set; } = new List<Module>();
		public class Module
		{
			/// <summary>
			/// 菜单名称
			/// </summary>
			public string Title { get; set; } = "未命名模块";

			/// <summary>
			/// 菜单2级分组
			/// </summary>
			public List<Group> Groups { get; set; } = new List<Group>();
			public class Group
			{
				/// <summary>
				/// 分组名称
				/// </summary>
				public string Title { get; set; } = "未命名分组";

				/// <summary>
				/// 链接
				/// </summary>
				public List<Link> Links { get; set; } = new List<Link>();
				public class Link
				{
					/// <summary>
					/// 连接名称
					/// </summary>
					public string Name { get; set; } = "未命名链接";

					/// <summary>
					///
					/// </summary>
					public string Href { get; set; } = "#";
				}

			}
		}
	}
}

