using MockServer.Web.Controllers.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MockServer.Web.Areas.Users.Controllers
{
    [OAuthorize]
    public class PagesController : Controller
    {
        // GET: Users/Pages
        public ActionResult Index()
        {
            return View();
        }
    }
}