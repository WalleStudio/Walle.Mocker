using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MockServer.Core.Domain.TCFlyMock.Enums;

namespace MockServer.Core.Dal.TCFlyMock
{
    public interface IFlightMockMatchRuleDal 
    {
        bool Delete(long id);
        long Add(FlightMockMatchRule rule);
        FlightMockMatchRule Query(long id);
        IEnumerable<FlightMockMatchRule> QueryPage(long startIndex, long pageSize);
        long Count();
        long UpdateById(long id, FlightMockMatchRule rule);
        IEnumerable<FlightMockMatchRule> Query(IEnumerable<long> ids);
        bool UpdateState(int id, MockRuleState state);
    }
}
