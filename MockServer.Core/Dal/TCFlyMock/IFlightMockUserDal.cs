using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Dal.TCFlyMock
{
    public interface IFlightMockUserDal
    {
        FlightMockUser QueryByUserId(int userId);
        IEnumerable<FlightMockUser> QueryAll();
        long Add(FlightMockUser mockUser);
        bool Update(FlightMockUser mockUser);
    }
}
