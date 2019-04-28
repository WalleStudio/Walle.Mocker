using MockServer.Core.Dal.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Dal.TCFlyMock
{
    public class FlightMockMatchUrlDal :DalClient, IFlightMockMatchUrlDal
    {
        public long Add(FlightMockMatchUrl url)
        {
            return DataClient.Add(url);
        }

        public IEnumerable<FlightMockMatchUrl> Query(IEnumerable<long> urlIds)
        {
            var idArray = string.Join(",", urlIds);
            var sql = $"select * from FlightMockMatchUrl where 1=1 and id in ({idArray})";
            var result = DataClient.Query<FlightMockMatchUrl>(sql);
            return result;
        }

        public IEnumerable<FlightMockMatchUrl> QueryByUrl(string url)
        {
            var sql = $"select * from FlightMockMatchUrl where 1=1 and Url = '{url}'";
            var result = DataClient.Query<FlightMockMatchUrl>(sql);
            return result;
        }
    }
}
