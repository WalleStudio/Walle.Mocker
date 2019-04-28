using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Biz.Rules
{
    public interface IFlightMockRuleQueryBiz
    {
        List<FlightMockMatchRule> QueryByUrl(string url);

        List<FlightMockMatchRule> GetList(long startIndex, long pageSize, long projectId);

        long GetCount(long projectId);

        FlightMockMatchRule GetDetail(long id);
    }
}
