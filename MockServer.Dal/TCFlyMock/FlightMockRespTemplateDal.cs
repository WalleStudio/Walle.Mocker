using MockServer.Core.Dal.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Dal.TCFlyMock
{
    public class FlightMockRespTemplateDal : DalClient, IFlightMockRespTemplateDal
    {
        public long Add(FlightMockRespTemplate respTemplate)
        {
            return DataClient.Add(respTemplate);
        }

        public FlightMockRespTemplate Query(long v)
        {
            var sql = $"select * from FlightMockRespTemplate where 1=1 and id = {v}";
            var result = DataClient.Query<FlightMockRespTemplate>(sql);
            if (result != null && result.Any())
            {
                return result.First();
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<FlightMockRespTemplate> Query(IEnumerable<long> respIds)
        {
            var respIdArray = string.Join(",", respIds);
            var sql = $"select * from FlightMockRespTemplate where 1=1 and id in( {respIdArray})";
            var result = DataClient.Query<FlightMockRespTemplate>(sql);
            return result;
        }
    }
}
