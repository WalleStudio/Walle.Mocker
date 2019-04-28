using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Biz.Users
{
    public interface IFlightMockUserBiz
    {
        /// <summary>
        /// 同步用户信息
        /// </summary>
        /// <param name="user"></param>
        void SyncUser(FlightMockUser user);
        IEnumerable<FlightMockUser> QueryAll();
    }
}
