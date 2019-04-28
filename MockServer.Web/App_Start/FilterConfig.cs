
using MockServer.Web.Controllers.Filter;
using System.Web;
using System.Web.Mvc;

namespace MockServer.Web
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		//	filters.Add(new OAuthorizeAttribute());
		}
	}
}
