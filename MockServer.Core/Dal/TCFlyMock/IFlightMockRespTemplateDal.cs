using MockServer.Core.Dal;
using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Dal.TCFlyMock
{
    public interface IFlightMockRespTemplateDal
    {
        long Add(FlightMockRespTemplate respTemplate);
        FlightMockRespTemplate Query(long v);
        IEnumerable<FlightMockRespTemplate> Query(IEnumerable<long> respIds);
    }
}
