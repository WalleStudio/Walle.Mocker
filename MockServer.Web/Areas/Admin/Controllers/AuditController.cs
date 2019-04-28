using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MockServer.Web.Areas.Admin.Controllers
{
    public class AuditController : Controller
    {
        /// <summary>
        /// 项目审核
        /// </summary>
        /// <returns></returns>
        public ActionResult Project()
        {
            return View();
        }

        /// <summary>
        /// 用户组加入审核
        /// </summary>
        /// <returns></returns>
        public ActionResult Permission()
        {
            return View();
        }
    }
}