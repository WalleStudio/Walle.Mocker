using System;
using System.Web.Mvc;
using MockServer.Web.Models;
using MockServer.Core.Biz.Projects;
using MockServer.Web.Controllers.Filter;

namespace MockServer.Web.Areas.Admin.Controllers
{
    [OAuthorize]
    public class ApiController : Controller
    {
        #region Private
        private IFlightMockProjectBiz FlightMockProjectBiz { get; set; }
        public ApiController(IFlightMockProjectBiz FlightMockProjectBiz)
        {
            this.FlightMockProjectBiz = FlightMockProjectBiz;
        }
        #endregion
    }
}