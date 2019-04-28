using MockServer.Core.Domain.TCFlyMock.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCBase.Data;

namespace MockServer.Core.Domain.TCFlyMock
{
    public class FlightMockMatchRule
    {
        public long Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string RequestMethod { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string RequestBody { get; set; } = string.Empty;
        public string MatchPattern { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        [Ignore]
        public MockRuleState StateEnum
        {
            get
            {
                if (State == MockRuleState.Active.ToString())
                {
                    return MockRuleState.Active;
                }
                else
                {
                    return MockRuleState.Frozen;
                }
            }
        }

        /// <summary>
        /// 多个Url , 未经过处理,默认为空
        /// </summary>
        [Ignore]
        public List<FlightMockMatchUrl> Urls { get; set; } = new List<FlightMockMatchUrl>();

        /// <summary>
        /// 规则对应的返回模板, 未经过处理,默认为空
        /// </summary>
        [Ignore]
        public FlightMockRespTemplate ResponseTemplate { get; set; } = new FlightMockRespTemplate();

        /// <summary>
        /// 所属项目id
        /// </summary>
        [Ignore]
        public long ProjectId = 0;

        /// <summary>
        /// 请求url
        /// </summary>
        [Ignore]
        public string Url = string.Empty;
    }
}
