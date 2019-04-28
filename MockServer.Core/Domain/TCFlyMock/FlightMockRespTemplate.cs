using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCBase.Data;

namespace MockServer.Core.Domain.TCFlyMock
{
    public class FlightMockRespTemplate
    {
        public long Id { get; set; } = 0;
        public int StatusCode { get; set; }
        public string ContentType { get; set; }
        public string ResponseBody { get; set; }

        /// <summary>
        /// 多个返回header
        /// </summary>
        [Ignore]
        public List<FlightMockRespHeader> RespHeaders = new List<FlightMockRespHeader>();
    }
}
