using MockServer.Common.Logger;
using MockServer.Core.Biz.Rules;
using MockServer.Core.Dal.TCFlyMock;
using MockServer.Core.Dal.TCFlyMock.Mapper;
using MockServer.Core.Domain.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock.Enums;
using MockServer.Core.Domain.TCFlyMock.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MockServer.Biz.Rules
{
    public class FlightMockRuleQueryBiz : IFlightMockRuleQueryBiz
    {
        private IFlightMockMapperDal FlightMockMapperDal { get; set; }
        private IFlightMockMatchRuleDal FlightMockMatchRuleDal { get; set; }
        private IFlightMockMatchUrlDal FlightMockMatchUrlDal { get; set; }
        private IFlightMockRespHeaderDal FlightMockRespHeaderDal { get; set; }
        private IFlightMockRespTemplateDal FlightMockRespTemplateDal { get; set; }
        public FlightMockRuleQueryBiz(
          IFlightMockMapperDal FlightMockMapperDal,
          IFlightMockMatchRuleDal FlightMockMatchRuleDal,
          IFlightMockMatchUrlDal FlightMockMatchUrlDal,
          IFlightMockRespHeaderDal FlightMockRespHeaderDal,
          IFlightMockRespTemplateDal FlightMockRespTemplateDal)
        {

            this.FlightMockMapperDal = FlightMockMapperDal;
            this.FlightMockMatchRuleDal = FlightMockMatchRuleDal;
            this.FlightMockMatchUrlDal = FlightMockMatchUrlDal;
            this.FlightMockRespHeaderDal = FlightMockRespHeaderDal;
            this.FlightMockRespTemplateDal = FlightMockRespTemplateDal;
        }

        public List<FlightMockMatchRule> QueryByUrl(string url)
        {
            List<FlightMockMatchRule> rules = new List<FlightMockMatchRule>();
            var urls = FlightMockMatchUrlDal.QueryByUrl(url);
            if (urls != null && urls.Any())
            {
                var ids = urls.Select(p => p.Id);
                var ruleUrlMaps = FlightMockMapperDal.QueryByValue(ids, MapCategoryEnum.MockRule2Url);
                var ruleIds = ruleUrlMaps.Select(p => p.KeyId);
                var ruleProjMaps = FlightMockMapperDal.QueryByValue(ruleIds, MapCategoryEnum.Project2Rule);
                ruleIds = ruleProjMaps.Where(p => p.Category == MapCategoryEnum.Project2Rule.ToString()).Select(p => p.ValueId);
                foreach (var ruleId in ruleIds)
                {
                    try
                    {
                        var rule = this.GetDetail(ruleId);
                        if (rule != null && rule.StateEnum == MockRuleState.Active)
                        {
                            rules.Add(rule);
                        }
                    }
                    catch (Exception ex)
                    {
                        SkyNetLogger.LogError("根据url反查规则详情异常.", ex);
                        continue;
                    }
                }
            }
            return rules;
        }
        public FlightMockMatchRule GetDetail(long id)
        {
            var rule = new FlightMockMatchRule();
            rule = FlightMockMatchRuleDal.Query(id);
            IEnumerable<long> projects = FlightMockMapperDal.QueryByValue(id, MapCategoryEnum.Project2Rule);
            if (projects == null)
            {
                rule.ProjectId = FlightMockMapperDal.QueryByValue(id, MapCategoryEnum.Project2RuleDelete).First();
            }
            else
            {
                rule.ProjectId = projects.First();
            }
            //查询url
            var urlIds = FlightMockMapperDal.QueryByKey(rule.Id, MapCategoryEnum.MockRule2Url);
            var urls = FlightMockMatchUrlDal.Query(urlIds);
            //查询resp及resp的headers
            var respTemplateId = FlightMockMapperDal.QueryByKey(rule.Id, MapCategoryEnum.MockRule2MockResp);
            var respTemplate = FlightMockRespTemplateDal.Query(respTemplateId.FirstOrDefault());
            var respHeaderIds = FlightMockMapperDal.QueryByKey(respTemplate.Id, MapCategoryEnum.MockResp2MockRespHeader);
            if (respHeaderIds != null && respHeaderIds.Any())
            {
                var respHeaders = FlightMockRespHeaderDal.Query(respHeaderIds);
                respTemplate.RespHeaders = respHeaders.ToList();
            }

            rule.ResponseTemplate = respTemplate;
            rule.Urls = urls.ToList();
            return rule;
        }
        public long GetCount(long projectId)
        {
            var cnt = FlightMockMapperDal.CountByKey(projectId, MapCategoryEnum.Project2Rule);
            return cnt;
        }
        public List<FlightMockMatchRule> GetList(long startIndex, long pageSize, long projectId)
        {
            var maps = FlightMockMapperDal.QueryPage(startIndex, pageSize, projectId, MapCategoryEnum.Project2Rule);
            if (maps != null && maps.Any())
            {
                var values = maps.Select(p => p.ValueId);
                var result = FlightMockMatchRuleDal.Query(values);
                return result?.ToList();
            }
            return null;
        }
    }
}
