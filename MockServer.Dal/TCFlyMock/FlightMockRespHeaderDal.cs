using MockServer.Core.Dal.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Dal.TCFlyMock
{
    public class FlightMockRespHeaderDal : DalClient, IFlightMockRespHeaderDal
    {
        public long Add(FlightMockRespHeader respHeader)
        {
            return DataClient.Add(respHeader);
        }

        public IEnumerable<FlightMockRespHeader> Query(IEnumerable<long> respHeaderIds)
        {
            var idArray = string.Join(",", respHeaderIds);
            var sql = $"select * from FlightMockRespHeader where 1=1 and id in ({idArray})";
            var result = DataClient.Query<FlightMockRespHeader>(sql);
            return result;
        }
    }
}
