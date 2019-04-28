using MockServer.Core.Domain.TCFlyMock.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Dal.TCFlyMock.Mapper
{
    public interface IFlightMockMapperDal
    {
        long CreateMap(long keyId, long valueId, MapCategoryEnum category);
        long CountByKey(long keyId, MapCategoryEnum category);
        IEnumerable<long> QueryByKey(long keyId, MapCategoryEnum category);
        FlightMockMapper Query(long keyId, long valueId, MapCategoryEnum category);
        IEnumerable<long> QueryByValue(long valueId, MapCategoryEnum category);
        IEnumerable<FlightMockMapper> QueryByValue2(long valueId, MapCategoryEnum category);
        IEnumerable<FlightMockMapper> QueryPage(long pageIndex, long pageSize, long keyId, MapCategoryEnum category);
        /// <summary>
        /// 更新指定映射分类
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        long UpdateCategory(IEnumerable<long> ids, MapCategoryEnum category);
        IEnumerable<FlightMockMapper> QueryByValue(IEnumerable<long> valueIds, MapCategoryEnum category);
        IEnumerable<FlightMockMapper> QueryByKey(IEnumerable<long> ruleIds, MapCategoryEnum category);
        /// <summary>
        /// 根据关系模块查询
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        IEnumerable<FlightMockMapper> Query(MapCategoryEnum category);
    }
}
