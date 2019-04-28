using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockServer.Web.Models
{
	public class UserInfoViewModel
	{
		public string UserName { get; set; } = string.Empty;

		public string Department { get; set; } = string.Empty;

		public string WorkId { get; set; } = string.Empty;

		public string UserId { get; set; } = string.Empty;

		public string DepartmentId { get; set; } = string.Empty;

		public long RoleId { get; set; } = 0;
	}
}