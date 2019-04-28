using MockServer.Web.Controllers.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MockServer.Web.Areas.Projects.Controllers
{
    [OAuthorize]
    public class PagesController : Controller
    {
        /// <summary>
        /// 项目列表页
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 3600)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增项目
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 3600)]
        public ActionResult Add()
        {
            return View();
        }
    }
}