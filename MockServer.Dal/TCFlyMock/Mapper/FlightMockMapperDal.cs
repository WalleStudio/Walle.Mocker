using MockServer.Core.Dal.TCFlyMock.Mapper;
using MockServer.Core.Domain.TCFlyMock.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCBase.Data;

namespace MockServer.Dal.TCFlyMock.Mapper
{
    public class FlightMockMapperDal : DalClient, IFlightMockMapperDal
    {
        public long CountByKey(long keyId, MapCategoryEnum category)
        {
            var sql = $"select count(Id) from FlightMockMapper where Category = '{category.ToString()}'";
            var result = DataClient.QueryScalar<long>(sql);
            if (result.HasValue)
            {
                return result.Value;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 建立映射
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="valueId"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public long CreateMap(long keyId, long valueId, MapCategoryEnum category)
        {
            FlightMockMapper mapper = new FlightMockMapper();
            mapper.Category = category.ToString();
            mapper.KeyId = keyId;
            mapper.ValueId = valueId;
            mapper.CreateTime = DateTime.Now;
            var result = DataClient.Add(mapper);
            return result;
        }

        public IEnumerable<FlightMockMapper> Query(MapCategoryEnum category)
        {
            var result = DataClient.Query<FlightMockMapper>($"select * from FlightMockMapper where Category = '{category.ToString()}'");
            return result;
        }

        public FlightMockMapper Query(long keyId, long valueId, MapCategoryEnum category)
        {
            var result = DataClient.Query<FlightMockMapper>($"select * from FlightMockMapper where Category = '{category.ToString()}'  and KeyId={keyId}  and ValueId={valueId}");
            if (result != null && result.Any())
            {
                return result.First();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据key查询
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public IEnumerable<long> QueryByKey(long keyId, MapCategoryEnum category)
        {
            var result = DataClient.Query<FlightMockMapper>($"select * from FlightMockMapper where KeyId={keyId}  and Category = '{category.ToString()}'");
            if (result != null && result.Any())
            {
                var values = result.Select(p => p.ValueId);
                return values;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<FlightMockMapper> QueryByKey(IEnumerable<long> ruleIds, MapCategoryEnum category)
        {
            var keyArray = string.Join(",", ruleIds);
            var result = DataClient.Query<FlightMockMapper>($"select * from FlightMockMapper where KeyId in ({keyArray})  and Category = '{category.ToString()}'");
            return result;
        }

        public IEnumerable<long> QueryByValue(long valueId, MapCategoryEnum category)
        {
            var result = DataClient.Query<FlightMockMapper>($"select * from FlightMockMapper where ValueId={valueId} and Category = '{category.ToString()}'");
            if (result != null && result.Any())
            {
                var keys = result.Select(p => p.KeyId);
                return keys;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<FlightMockMapper> QueryByValue(IEnumerable<long> valueIds, MapCategoryEnum category)
        {
            var valueArray = string.Join(",", valueIds);
            var result = DataClient.Query<FlightMockMapper>($"select * from FlightMockMapper where ValueId in({valueArray}) and Category = '{category.ToString()}'");
            return result;
        }

        public IEnumerable<FlightMockMapper> QueryByValue2(long valueId, MapCategoryEnum category)
        {
            var result = DataClient.Query<FlightMockMapper>($"select * from FlightMockMapper where ValueId={valueId} and Category = '{category.ToString()}'");
            return result;
        }

        public IEnumerable<FlightMockMapper> QueryPage(long pageIndex, long pageSize, long keyId, MapCategoryEnum category)
        {
            var startIndex = (pageIndex - 1) * pageSize;
            var result = DataClient.Query<FlightMockMapper>($"select * from FlightMockMapper where KeyId={keyId} and Category = '{category.ToString()}' limit {startIndex},{pageSize}");
            if (result != null && result.Any())
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public long UpdateCategory(IEnumerable<long> ids, MapCategoryEnum category)
        {
            var idArray = string.Join(",", ids);
            var result = DataClient.ExecuteWriteSql($"update FlightMockMapper set  Category = '{category.ToString()}' where id in ({idArray})");
            return result;
        }
    }
}
