using MockServer.Core.Biz.Users;
using MockServer.Core.Dal.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Biz.Users
{
    public class FlightMockUserBiz : IFlightMockUserBiz
    {
        private IFlightMockUserDal FlightMockUserDal { get; set; }
        public FlightMockUserBiz(IFlightMockUserDal FlightMockUserDal)
        {
            this.FlightMockUserDal = FlightMockUserDal;
        }

        public void SyncUser(FlightMockUser user)
        {
            var result = FlightMockUserDal.QueryByUserId(user.UserId);
            if (result == null)
            {
                FlightMockUserDal.Add(user);
            }
            else
            {
                if (result.DepartmentId != user.DepartmentId || result.Department != user.Department)
                {
                    result.Department = user.Department;
                    result.DepartmentId = user.DepartmentId;
                    FlightMockUserDal.Update(result);
                }
            }
        }

        public IEnumerable<FlightMockUser> QueryAll()
        {
            var result = FlightMockUserDal.QueryAll();
            return result;
        }
    }
}
