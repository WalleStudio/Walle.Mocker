using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Dal.TCFlyMock
{
    public interface IFlightMockProjectDal
    {
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="mockProject"></param>
        /// <returns></returns>
        bool Update(FlightMockProject mockProject);
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="mockProject"></param>
        /// <returns></returns>
        long Add(FlightMockProject mockProject);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="ids">主键ID集合</param>
        /// <param name="mockProject">条件</param>
        /// <returns></returns>
        IEnumerable<FlightMockProject> QueryByPage(int pageIndex, int pageSize, List<long> ids, FlightMockProject mockProject);
        /// <summary>
        /// 分页查询(不是指定ID集合)
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="ids">主键ID集合</param>
        /// <param name="mockProject">条件</param>
        /// <returns></returns>
        IEnumerable<FlightMockProject> QueryByPageNonIds(int pageIndex, int pageSize, List<long> ids, FlightMockProject mockProject);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="mockProject">条件</param>
        /// <returns></returns>
        IEnumerable<FlightMockProject> QueryByPage(int pageIndex, int pageSize, FlightMockProject mockProject);
        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="mockProject">条件</param>
        /// <returns></returns>
        int QueryCount(FlightMockProject mockProject);
        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <param name="mockProject">条件</param>
        /// <returns></returns>
        int QueryCount(List<long> ids, FlightMockProject mockProject);
        /// <summary>
        /// 查询数量（不在ID集合类的）
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <param name="mockProject">条件</param>
        /// <returns></returns>
        int QueryCountNonIds(List<long> ids, FlightMockProject mockProject);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FlightMockProject Query(long id);
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        bool Update(long id, string state);
        /// <summary>
        ///查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        FlightMockProject Query(string name);
    }
}
