using MockServer.Core.Dal;
using MockServer.Core.Dal.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Dal.TCFlyMock
{
    public interface IFlightMockRespHeaderDal
    {

        long Add(FlightMockRespHeader respHeader);
        IEnumerable<FlightMockRespHeader> Query(IEnumerable<long> respHeaderIds);
    }
}
