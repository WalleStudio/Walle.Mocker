using MockServer.Core.Dal;
using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Dal.TCFlyMock
{
    public interface IFlightMockMatchUrlDal
    {
        long Add(FlightMockMatchUrl url);
        IEnumerable<FlightMockMatchUrl> Query(IEnumerable<long> urlIds);
        IEnumerable<FlightMockMatchUrl> QueryByUrl(string url);
    }
}
