using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MockServer.Web.Areas.Rules.Controllers
{
    /// <summary>
    /// 只负责页面呈现, 页面数据由Js进行. 本控制器输出纯html内容.
    /// </summary>
    public class PagesController : Controller
    {
        /// <summary>
        /// 规则列表页面
        /// </summary>
        /// <returns></returns>
        ///[OutputCache(Duration = 3600)]
        public ActionResult List(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="id">项目Id</param>
        /// <returns></returns>
     //   [OutputCache(Duration = 3600)]
        public ActionResult Add(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
       // [OutputCache(Duration = 3600)]
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// 详情页
        /// </summary>
        /// <returns></returns>
      //  [OutputCache(Duration = 3600)]
        public ActionResult Detail(int id)
        {

            ViewBag.Id = id;
            return View();
        }
    }
}