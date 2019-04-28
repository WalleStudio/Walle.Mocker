using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MockServer.Core.Biz.Rules
{
    public interface IFlightMockMatchBiz
    { 
        FlightMockMatchRule Match(FlightMockMatchRule rule);
    }
}
