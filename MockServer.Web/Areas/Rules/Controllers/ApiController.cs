using MockServer.Common.Logger;
using MockServer.Common.External;
using MockServer.Core.Biz.Rules;
using MockServer.Core.Domain.TCFlyMock;
using MockServer.Web.Areas.Rules.Models;
using MockServer.Web.Controllers.Filter;
using MockServer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MockServer.Core.Domain.TCFlyMock.Enums;

namespace MockServer.Web.Areas.Rules.Controllers
{
    [OAuthorize]
    public class ApiController : Controller
    {
        private IFlightMockRuleBiz FlightMockRuleBiz { get; set; }
        private IFlightMockRuleQueryBiz FlightMockRuleQueryBiz { get; set; }
        public ApiController(IFlightMockRuleBiz FlightMockRuleBiz, IFlightMockRuleQueryBiz FlightMockRuleQueryBiz)
        {
            this.FlightMockRuleBiz = FlightMockRuleBiz;
            this.FlightMockRuleQueryBiz = FlightMockRuleQueryBiz;
        }

        private FlightMockMatchRule Convert(RuleCreateViewModel ruleModel)
        {
            FlightMockMatchRule rule = new FlightMockMatchRule();
            rule.Description = ruleModel.Desc;
            rule.MatchPattern = ruleModel.MatchPattern;
            rule.Name = ruleModel.Name;
            rule.ProjectId = ruleModel.ProjectId;
            rule.State = MockRuleState.Active.ToString();
            rule.ContentType = ruleModel.RequestContentType;
            rule.RequestBody = ruleModel.RequestBody;
            rule.RequestMethod = ruleModel.RequestMethod;
            rule.ResponseTemplate.ResponseBody = ruleModel.ResponseBody;
            foreach (var item in ruleModel.ResponseHeaders)
            {
                if (!string.IsNullOrEmpty(item.Key) && !string.IsNullOrEmpty(item.Value))
                {
                    rule.ResponseTemplate.RespHeaders.Add(new FlightMockRespHeader
                    {
                        Name = item.Key,
                        Value = item.Value
                    });
                }
            }
            foreach (var item in ruleModel.Urls)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    rule.Urls.Add(new FlightMockMatchUrl
                    {
                        Url = item.ToString()
                    });
                }
            }
            rule.ResponseTemplate.ContentType = ruleModel.ResponseContentType;
            rule.ResponseTemplate.StatusCode = ruleModel.ResponseStatusCode;
            return rule;
        }


        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Create(RuleCreateViewModel ruleModel)
        {
            JsonMessage message = new JsonMessage();
            if (!ModelState.IsValid)
            {
                message.Message = JsonMessage.GetErrorMsg(ModelState);
                message.Type = JsonMessage.MsgType.Error;
                message.Result = false;
                return Json(message);
            }
            try
            {
                FlightMockMatchRule rule = Convert(ruleModel);
                var id = FlightMockRuleBiz.Create(rule);
                message.Message = "创建成功";
                message.Result = true;
                message.Data = id;
                message.Type = JsonMessage.MsgType.Success;
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.Type = JsonMessage.MsgType.Error;
                message.Result = false;
            }
            return Json(message);
        }
        [HttpGet]
        public JsonResult Detail(int id)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                var rule = FlightMockRuleQueryBiz.GetDetail(id);
                RuleDetailViewModel result = new RuleDetailViewModel();
                result.Name = rule.Name;
                result.Desc = rule.Description;
                result.Id = rule.Id;

                foreach (var item in rule.Urls)
                {
                    result.Urls.Add(item.Url);
                }
                result.RequestBody = rule.RequestBody;
                result.MatchPattern = rule.MatchPattern;
                result.RequestMethod = rule.RequestMethod;
                result.RequestContentType = rule.ContentType;
                result.ResponseBody = rule.ResponseTemplate.ResponseBody;
                result.ResponseContentType = rule.ResponseTemplate.ContentType;
                result.ResponseStatusCode = rule.ResponseTemplate.StatusCode;
                result.ProjectId = rule.ProjectId;
                foreach (var item in rule.ResponseTemplate.RespHeaders)
                {
                    result.ResponseHeaders.Add(new RuleDetailViewModel.Header
                    {
                        Key = item.Name,
                        Value = item.Value
                    });
                }
                result.IsActive = rule.State.Trim() == MockRuleState.Active.ToString();
                message.Data = result;
                message.Message = $"查询{rule.Name}的详情成功";
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.Type = JsonMessage.MsgType.Error;
                message.Result = false;
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                var result = FlightMockRuleBiz.SoftDelete(id);
                message.Data = result;
                message.Message = $"成功删除{result}个规则";
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.Type = JsonMessage.MsgType.Error;
                message.Result = false;
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Active(int id)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                var result = FlightMockRuleBiz.Active(id);
                message.Data = result;
                message.Message = $"成功激活规则";
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.Type = JsonMessage.MsgType.Error;
                message.Result = false;
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Frozen(int id)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                var result = FlightMockRuleBiz.Frozen(id);
                message.Data = result;
                message.Message = $"成功冻结 规则";
                message.Type = JsonMessage.MsgType.Warn;
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.Type = JsonMessage.MsgType.Error;
                message.Result = false;
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Update(RuleUpdateViewModel ruleModel)
        {
            JsonMessage message = new JsonMessage();
            if (!ModelState.IsValid)
            {
                message.Message = JsonMessage.GetErrorMsg(ModelState);
                message.Type = JsonMessage.MsgType.Error;
                message.Result = false;
                return Json(message);
            }
            try
            {
                FlightMockMatchRule rule = Convert(ruleModel);
                var id = FlightMockRuleBiz.Create(rule);
                if (id <= 0)
                {
                    message.Message = "更新失败";
                    message.Result = false;
                    message.Data = id;
                    message.Type = JsonMessage.MsgType.Success;
                }
                else
                {
                    var result = FlightMockRuleBiz.SoftDelete(int.Parse(ruleModel.Id.ToString()));
                    message.Message = "更新成功";
                    message.Result = true;
                    message.Data = id;
                    message.Type = JsonMessage.MsgType.Success;
                }
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.Type = JsonMessage.MsgType.Error;
                message.Result = false;
            }
            return Json(message);
        }



        [HttpGet]
        public JsonResult List(long startIndex, long pageSize, long projectId)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                RuleListViewModel result = new RuleListViewModel();
                result.Index = startIndex;
                result.Size = pageSize;
                result.ProjectId = projectId;
                var rulelst = FlightMockRuleQueryBiz.GetList(startIndex, pageSize, projectId);
                if (rulelst != null && rulelst.Any())
                {
                    rulelst = rulelst.OrderByDescending(p => p.Id).ToList();
                    foreach (var item in rulelst)
                    {
                        result.RuleList.Add(new RuleDetailViewModel
                        {
                            Id = item.Id,
                            Desc = item.Description,
                            Name = item.Name,
                            IsActive = item.State == MockRuleState.Active.ToString(),
                            RequestMethod = item.RequestMethod
                        });
                    }
                    result.Total = FlightMockRuleQueryBiz.GetCount(projectId);
                    message.Data = result;
                    message.Message = $"规则数据总数{result.Total},当前页{startIndex}";
                }
                else
                {
                    message.Type = JsonMessage.MsgType.Warn;
                    message.Message = "暂无规则数据";
                }
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.Type = JsonMessage.MsgType.Error;
                message.Result = false;
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}