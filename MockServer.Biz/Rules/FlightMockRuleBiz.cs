using MockServer.Core.Biz.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MockServer.Core.Domain.TCFlyMock;
using MockServer.Core.Dal.TCFlyMock;
using MockServer.Core.Dal.TCFlyMock.Mapper;
using MockServer.Core.Domain.TCFlyMock.Mapper;
using MockServer.Core.Domain.TCFlyMock.Enums;
using MockServer.Common;
using MockServer.Common.External;

namespace MockServer.Biz.Rules
{
    public class FlightMockRuleBiz : IFlightMockRuleBiz
    {
        private IFlightMockMapperDal FlightMockMapperDal { get; set; }
        private IFlightMockMatchRuleDal FlightMockMatchRuleDal { get; set; }
        private IFlightMockMatchUrlDal FlightMockMatchUrlDal { get; set; }
        private IFlightMockRespHeaderDal FlightMockRespHeaderDal { get; set; }
        private IFlightMockRespTemplateDal FlightMockRespTemplateDal { get; set; }
        public FlightMockRuleBiz(
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



        public long Create(FlightMockMatchRule rule)
        {
            if (JsonTextHelper.IsJson(rule.RequestBody))
            {
                rule.RequestBody = JsonTextHelper.RetrenchJsonText(rule.RequestBody);
            }

            var ruleId = FlightMockMatchRuleDal.Add(rule);
            FlightMockMapperDal.CreateMap(rule.ProjectId, ruleId, MapCategoryEnum.Project2Rule);

            //保存url
            foreach (var url in rule.Urls)
            {
                var urlId = FlightMockMatchUrlDal.Add(url);
                FlightMockMapperDal.CreateMap(ruleId, urlId, MapCategoryEnum.MockRule2Url);
            }
            //保存返回
            var respTemplate = rule.ResponseTemplate;
            var templateId = FlightMockRespTemplateDal.Add(respTemplate);
            FlightMockMapperDal.CreateMap(ruleId, templateId, MapCategoryEnum.MockRule2MockResp);

            //保存返回头
            foreach (var respHeader in respTemplate.RespHeaders)
            {
                var headerId = FlightMockRespHeaderDal.Add(respHeader);
                FlightMockMapperDal.CreateMap(templateId, headerId, MapCategoryEnum.MockResp2MockRespHeader);
            }
            return ruleId;
        }

        public bool Update(FlightMockMatchRule rule)
        {
            var id = rule.Id;
            var result = FlightMockMatchRuleDal.UpdateById(id, rule);
            return result > 0;
        }


        public long SoftDelete(int id)
        {
            var map = FlightMockMapperDal.QueryByValue2(id, MapCategoryEnum.Project2Rule);
            if (map != null && map.Any())
            {
                var ids = map.Select(p => p.Id);
                var result = FlightMockMapperDal.UpdateCategory(ids, MapCategoryEnum.Project2RuleDelete);
                return result;
            }
            else
            {
                return 0;
            }
        }

        public bool Active(int id)
        {
            bool result = FlightMockMatchRuleDal.UpdateState(id, MockRuleState.Active);
            return result;

        }

        public bool Frozen(int id)
        {
            bool result = FlightMockMatchRuleDal.UpdateState(id, MockRuleState.Frozen);
            return result;
        }
    }
}
