using AutoMapper;
using MockServer.Core.Biz.Projects;
using MockServer.Core.Domain;
using MockServer.Core.Domain.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock.Enums;
using MockServer.Web.Areas.Projects.Models;
using MockServer.Web.Controllers.Filter;
using MockServer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MockServer.Web.Areas.Projects.Controllers
{
    [OAuthorize]
    public class ApiController : Controller
    {
        private IFlightMockProjectBiz FlightMockProjectBiz { get; set; }
        public ApiController(IFlightMockProjectBiz FlightMockProjectBiz)
        {
            this.FlightMockProjectBiz = FlightMockProjectBiz;
        }

        public LyOAuthUserInfo UserInfo
        {
            get
            {
                return CurrentUser();
            }
        }

        #region  Private Method
        private LyOAuthUserInfo CurrentUser()
        {
            var userPrincipal = HttpContext.User as LyOAuthPrincipal;
            var userinfo = userPrincipal.UserData;
            return userinfo;
        }
        #endregion

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Add(ProjectAddViewModel addModel)
        {
            JsonMessage jsonMsg = new JsonMessage();
            try
            {
                string msg = string.Empty;
                if (ModelState.IsValid)
                {
                    string userInfo = UserInfo.UserName + UserInfo.WorkId;
                    FlightMockProject project = new FlightMockProject()
                    {
                        Description = addModel.Description,
                        Name = addModel.Name.Trim(),
                        Creator = userInfo,
                        Owner = string.IsNullOrWhiteSpace(addModel.Owner) ? userInfo : addModel.Owner,
                        State = MockProjectState.Initialize.ToString()
                    };
                    jsonMsg.Result = FlightMockProjectBiz.Create(project, UserInfo.DepartmentId, out msg);
                    jsonMsg.Message = msg;
                    if (!jsonMsg.Result)
                    {
                        jsonMsg.Type = JsonMessage.MsgType.Error;
                    }
                    return Json(jsonMsg);
                }
                else
                {
                    jsonMsg.Result = false;
                    jsonMsg.Message = "请正确完整输入表单!";
                    jsonMsg.Type = JsonMessage.MsgType.Warn;
                    return Json(jsonMsg);
                }
            }
            catch (Exception ex)
            {
                jsonMsg.Result = false;
                jsonMsg.Message = ex.Message;
                jsonMsg.Type = JsonMessage.MsgType.Error;
                return Json(jsonMsg);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(ProjectUpdateViewModel updateModel)
        {
            JsonMessage jsonMsg = new JsonMessage();
            try
            {
                string msg = string.Empty;
                if (ModelState.IsValid)
                {
                    FlightMockProject project = new FlightMockProject()
                    {
                        Id = updateModel.Id,
                        Description = updateModel.Description,
                        Name = updateModel.Name.Trim()
                    };
                    jsonMsg.Result = FlightMockProjectBiz.Edit(project, out msg);
                    jsonMsg.Message = msg;
                    if (!jsonMsg.Result)
                    {
                        jsonMsg.Type = JsonMessage.MsgType.Error;
                    }
                    return Json(jsonMsg);
                }
                else
                {
                    jsonMsg.Result = false;
                    jsonMsg.Message = "请正确完整输入表单!";
                    jsonMsg.Type = JsonMessage.MsgType.Warn;
                    return Json(jsonMsg);
                }
            }
            catch (Exception ex)
            {
                jsonMsg.Result = false;
                jsonMsg.Message = ex.Message;
                jsonMsg.Type = JsonMessage.MsgType.Error;
                return Json(jsonMsg);
            }
        }

        [HttpPost]
        public JsonResult PaginationQuery(ProjectPaginationQueryViewModel viewModel)
        {
            JsonMessage jsonMsg = new JsonMessage();
            try
            {
                IEnumerable<FlightMockProject> result = null;
                ProjectPaginationQueryResultViewModel queryResult = new ProjectPaginationQueryResultViewModel();
                FlightMockProject mockProject = new FlightMockProject() { IsPage = true, PageIndex = viewModel.CurrentPage, PageSize = viewModel.PageSize, State = MockProjectState.Valid.ToString() };
                switch (viewModel.Type)
                {
                    case ProjectPaginationQueryType.Joined:
                        mockProject.CurrentUser = UserInfo.UserName + UserInfo.WorkId;
                        result = FlightMockProjectBiz.QueryByDept(UserInfo.DepartmentId, mockProject);
                        queryResult.TotalCount = FlightMockProjectBiz.QueryCountByDept(UserInfo.DepartmentId, mockProject);
                        break;
                    case ProjectPaginationQueryType.UnJoined:
                        result = FlightMockProjectBiz.UnQueryByDept(UserInfo.DepartmentId, mockProject);
                        queryResult.TotalCount = FlightMockProjectBiz.UnQueryCountByDept(UserInfo.DepartmentId, mockProject);
                        break;
                    case ProjectPaginationQueryType.AuditProject:
                        mockProject.State = MockProjectState.Initialize.ToString();
                        result = FlightMockProjectBiz.Query(mockProject);
                        queryResult.TotalCount = FlightMockProjectBiz.QueryCount(mockProject);
                        break;
                    case ProjectPaginationQueryType.DepartmentApply:
                        mockProject.State = MockProjectState.Initialize.ToString();
                        result = FlightMockProjectBiz.Query(mockProject);
                        queryResult.TotalCount = FlightMockProjectBiz.QueryCount(mockProject);
                        break;
                }
                if (result != null && result.Any())
                {
                    queryResult.DetailInfo = Mapper.Map<List<ProjectPaginationQueryResultViewModel.Detail>>(result);
                    jsonMsg.Data = queryResult;
                    return Json(jsonMsg);
                }
                jsonMsg.Result = false;
                jsonMsg.Type = JsonMessage.MsgType.Warn;
                jsonMsg.Message = "未查询到数据!";
                return Json(jsonMsg);
            }
            catch (Exception ex)
            {
                jsonMsg.Result = false;
                jsonMsg.Message = ex.Message;
                jsonMsg.Type = JsonMessage.MsgType.Error;
                return Json(jsonMsg);
            }
        }

        [HttpGet]
        public JsonResult Detail(long id)
        {
            JsonMessage jsonMsg = new JsonMessage();
            try
            {
                ProjectQueryDetailResultViewModel queryResult = new ProjectQueryDetailResultViewModel();
                var result = FlightMockProjectBiz.Query(id);
                if (result != null)
                {
                    queryResult = Mapper.Map<ProjectQueryDetailResultViewModel>(result);
                }
                jsonMsg.Data = queryResult;
                return Json(jsonMsg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                jsonMsg.Result = false;
                jsonMsg.Message = ex.Message;
                jsonMsg.Type = JsonMessage.MsgType.Error;
                return Json(jsonMsg);
            }
        }

        /// <summary>
        /// 审核项目  
        /// </summary>
        /// <param name="id">项目Id</param>
        /// <param name="b">true: 审核通过； false: 驳回</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Audit(long id, bool b)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                string msg = string.Empty;
                var stage = b ? MockProjectState.Valid.ToString() : MockProjectState.Invalid.ToString();
                var result = FlightMockProjectBiz.UpdateState(id, stage);
                message.Message = b ? "审批成功" : "审批失败";
                message.Result = true;
                message.Type = JsonMessage.MsgType.Info;
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.Type = JsonMessage.MsgType.Error;
                message.Result = false;
                throw;
            }
            return Json(message);
        }

        /// <summary>
        /// 申请加入指定项目
        /// </summary>
        /// <param name="id">项目id</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ApplyJoin(long id)
        {
            JsonMessage jsonMsg = new JsonMessage();
            try
            {
                var result = FlightMockProjectBiz.ApplyJoin(UserInfo.DepartmentId, id);
                jsonMsg.Result = result;
                jsonMsg.Message = result ? "申请成功!" : "申请失败!";
                return Json(jsonMsg);
            }
            catch (Exception ex)
            {
                jsonMsg.Result = false;
                jsonMsg.Message = ex.Message;
                jsonMsg.Type = JsonMessage.MsgType.Error;
                return Json(jsonMsg);
            }
        }
    }
}