using MockServer.Core.Dal.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Dal.TCFlyMock
{
    public class FlightMockUserDal : DalClient, IFlightMockUserDal
    {
        public FlightMockUser QueryByUserId(int userId)
        {
            string sql = "select * from FlightMockUser where UserId=@userId  limit 1";
            var result = DataClient.Query<FlightMockUser>(sql, new { userId = userId });
            if (result != null && result.Any())
            {
                return result.First();
            }
            return null;
        }

        public IEnumerable<FlightMockUser> QueryAll()
        {
            var result = DataClient.QueryAll<FlightMockUser>();
            return result;
        }

        public long Add(FlightMockUser mockUser)
        {
            var result = DataClient.Add(mockUser);
            return result;
        }

        public bool Update(FlightMockUser mockUser)
        {
            var result = DataClient.Update(mockUser);
            return result;
        }
    }
}
