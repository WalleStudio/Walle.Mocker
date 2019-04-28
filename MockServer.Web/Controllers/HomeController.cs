using AutoMapper;
using MockServer.Core.Domain;
using MockServer.Web.Controllers.Filter;
using MockServer.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MockServer.Web.Controllers
{
    [OAuthorize]
    public class HomeController : Controller
    {
        [OutputCache(Duration = 20, VaryByParam = "")]
        public ActionResult Index()
        {
            ViewBag.Title = "Mocker";
            return RedirectToAction("Index", "Pages", new { Area = "Projects" });
        }

        /// <summary>
        /// 当前用户的目录信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [OutputCache(Duration = 20)]
        public JsonResult Menu()
        {
            MenuViewModel menu = new Models.MenuViewModel();
            var projectListlink = new MenuViewModel.Module.Group.Link()
            {
                Href = Url.Action("Index", "Pages", new { Area = "Projects" }),
                Name = "项目列表"
            };
            var createProjectlink = new MenuViewModel.Module.Group.Link()
            {
                Href = Url.Action("Add", "Pages", new { Area = "Projects" }),
                Name = "新建项目"
            };
            var auditProjectLink = new MenuViewModel.Module.Group.Link()
            {
                Href = Url.Action("Project", "Audit", new { Area = "Admin" }),
                Name = "项目审批"
            };
            var departmentApplyLink = new MenuViewModel.Module.Group.Link()
            {
                Href = Url.Action("Permission", "Audit", new { Area = "Admin" }),
                Name = "权限审批"
            };
            //链接分组
            var projectGrouplinks = new List<MenuViewModel.Module.Group.Link>();
            projectGrouplinks.Add(projectListlink);
            projectGrouplinks.Add(createProjectlink);

            var adminGroupLinks = new List<MenuViewModel.Module.Group.Link>();
            adminGroupLinks.Add(auditProjectLink);
            adminGroupLinks.Add(departmentApplyLink);

            var projectGroup = new MenuViewModel.Module.Group()
            {
                Links = projectGrouplinks,
                Title = "项目"
            };

            var adminGroup = new MenuViewModel.Module.Group()
            {
                Links = adminGroupLinks,
                Title = "管理"
            };
            //加入
            var groups = new List<MenuViewModel.Module.Group>();
            groups.Add(projectGroup);
            groups.Add(adminGroup);
            //菜单
            menu.Modules.Add(new Models.MenuViewModel.Module
            {
                Title = "控制面板",
                Groups = groups
            });


            return Json(menu, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 20)]
        [HttpGet]
        public JsonResult CurrentUser()
        {
            var userPrincipal = HttpContext.User as LyOAuthPrincipal;
            var userinfo = userPrincipal.UserData;
            var result = Mapper.Map<UserInfoViewModel>(userinfo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
