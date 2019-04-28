using MockServer.Core.Biz.Rules;
using MockServer.Core.Domain.TCFlyMock;
using MockServer.Core.Dal.TCFlyMock;
using MockServer.Core.Dal.TCFlyMock.Mapper;
using System.Linq;
using MockServer.Core.Domain.TCFlyMock.Mapper;
using MockServer.Core.Domain.TCFlyMock.Enums;
using System.Web;
using System;
using static MockServer.Common.External.RequestExt;
using MockServer.Common.Logger;
using MockServer.Common.External;
using MockServer.Common;
using System.Collections.Generic;
using System.Collections.Specialized;
using RazorEngine;

namespace MockServer.Biz.Rules
{
    public class FlightMockMatchBiz : IFlightMockMatchBiz
    {
        public IFlightMockRuleQueryBiz FlightMockRuleQueryBiz { get; set; }
        public FlightMockMatchBiz(IFlightMockRuleQueryBiz FlightMockRuleQueryBiz)
        {
            this.FlightMockRuleQueryBiz = FlightMockRuleQueryBiz;
        }
        public FlightMockMatchRule Match(FlightMockMatchRule rule)
        {
            if (JsonTextHelper.IsJson(rule.RequestBody))
            {
                rule.RequestBody = JsonTextHelper.RetrenchJsonText(rule.RequestBody);
            }
            var msg = string.Empty;
            msg += $"匹配条件为url:{rule.Url};body:{rule.RequestBody};method:{rule.RequestMethod}";
            FlightMockMatchRule resultRule = new FlightMockMatchRule();
            var newLine = Environment.NewLine;
            var reqMethod = rule.RequestMethod;
            var rules = FlightMockRuleQueryBiz.QueryByUrl(rule.Url);
            msg += $"根据url目标规则集合为:{newLine}{rules.ToJson()}{newLine}";
            var targetRules = rules.Where(p => p.RequestMethod == reqMethod);
            if (targetRules != null && targetRules.Any())
            {
                var reqBody = rule.RequestBody;
                targetRules = targetRules.Where(p => p.RequestBody.Trim() == reqBody.Trim());
                msg += $"根据method:{reqMethod},body:{reqBody.Trim()},筛选后:{newLine}{targetRules.ToJson()}{newLine}";
                if (targetRules != null && targetRules.Any())
                {
                    resultRule = targetRules.First();
                    msg += $"目标为:{newLine}{resultRule.ToJson()}";
                }
            }
            msg += $"目标为:{newLine}{resultRule.ToJson()}";
            SkyNetLogger.LogInfo(new SkyNetMarker("Biz", "FlightMockMatchBiz", "Match"), $"{rule.RequestMethod}{rule.Url}匹配日志为{newLine}{msg}");
            return resultRule;
        }
    }
}
