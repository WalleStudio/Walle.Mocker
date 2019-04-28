using MockServer.Core.Dal.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCBase.Data;
using MockServer.Core.Domain.TCFlyMock.Enums;

namespace MockServer.Dal.TCFlyMock
{
    public class FlightMockMatchRuleDal : DalClient, IFlightMockMatchRuleDal
    {
        public long Add(FlightMockMatchRule rule)
        {
            var result = DataClient.Add(rule);
            return result;
        }

        public long Count()
        {
            var result = DataClient.QueryScalar<long>("select count 1 from FlightMockMatchRule where 1 = 1");
            if (result.HasValue)
            {
                return result.Value;
            }
            else
            {
                return 0;
            }
        }

        public bool Delete(long id)
        {
            var result = DataClient.ExecuteWriteSql($"delete from FlightMockMatchRule where Id = {id}");
            return result > 0;
        }

        public FlightMockMatchRule Query(long id)
        {
            var result = DataClient.Query<FlightMockMatchRule>($"select * from FlightMockMatchRule where Id = {id}");
            if (result != null && result.Any())
            {
                return result.First();
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<FlightMockMatchRule> Query(IEnumerable<long> ids)
        {
            var idArray = string.Join(",", ids.ToArray());
            var result = DataClient.Query<FlightMockMatchRule>($"select * from FlightMockMatchRule where 1=1 and id in( {idArray})");
            if (result != null && result.Any())
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<FlightMockMatchRule> QueryPage(long startIndex, long pageSize)
        {
            var result = DataClient.Query<FlightMockMatchRule>($"select * from FlightMockMatchRule where 1=1 limit {startIndex},{pageSize}");
            if (result != null && result.Any())
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public long UpdateById(long id, FlightMockMatchRule rule)
        {
            rule.Id = id;
            var result = DataClient.Update(rule);
            return result ? 1 : 0;
        }

        public bool UpdateState(int id, MockRuleState state)
        {
            var sql = $"update FlightMockMatchRule set State = '{state.ToString()}' where id = {id}";
            var result = DataClient.ExecuteWriteSql(sql);
            return result > 0;
        }
    }
}
