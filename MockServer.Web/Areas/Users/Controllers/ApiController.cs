using AutoMapper;
using MockServer.Core.Biz.Users;
using MockServer.Core.Domain.TCFlyMock;
using MockServer.Web.Areas.Users.Models;
using MockServer.Web.Controllers.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MockServer.Web.Areas.Users.Controllers
{
    [OAuthorize]
    public class ApiController : Controller
    {
        private IFlightMockUserBiz FlightMockUserBiz { get; set; }
        public ApiController(IFlightMockUserBiz FlightMockUserBiz)
        {
            this.FlightMockUserBiz = FlightMockUserBiz;
        }

        [OutputCache(Duration = 60)]
        public JsonResult GetAllUsers()
        {
            List<UserSelectViewModel> allUsers = new List<UserSelectViewModel>();
            var result = FlightMockUserBiz.QueryAll();
            if (result != null && result.Any())
            {
                allUsers = Mapper.Map<List<UserSelectViewModel>>(result);
            }
            return Json(allUsers, JsonRequestBehavior.AllowGet);
        }
    }
}
