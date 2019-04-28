using MockServer.Core.Domain.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Biz.Projects
{
    public interface IFlightMockProjectBiz
    {
        /// <summary>
        /// 创建项目
        /// </summary>
        /// <param name="mockProject"></param>
        /// <param name="departmentId"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool Create(FlightMockProject mockProject, int departmentId, out string msg);
        /// <summary>
        /// 加入项目
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        bool Join(int departmentId, long projectId);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="mockProject">条件</param>
        /// <returns></returns>
        IEnumerable<FlightMockProject> Query(FlightMockProject mockProject);
        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="mockProject">条件</param>
        /// <returns></returns>
        int QueryCount(FlightMockProject mockProject);
        /// <summary>
        /// 查询该部门Id有权限的项目
        /// </summary>
        /// <param name="departmentId">部门Id</param>
        /// <param name="mockProject">条件</param>
        /// <returns></returns>
        IEnumerable<FlightMockProject> QueryByDept(int departmentId, FlightMockProject mockProject);
        /// <summary>
        /// 查询该部门Id有权限的项目数量
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="mockProject"></param>
        /// <returns></returns>
        int QueryCountByDept(int departmentId, FlightMockProject mockProject);
        /// <summary>
        /// 查询该部门Id没有权限的项目
        /// </summary>
        /// <param name="departmentId">部门Id</param>
        /// <param name="mockProject">条件</param>
        /// <returns></returns>
        IEnumerable<FlightMockProject> UnQueryByDept(int departmentId, FlightMockProject mockProject);
        /// <summary>
        /// 查询该部门Id没有有权限的项目数量
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="mockProject"></param>
        /// <returns></returns>
        int UnQueryCountByDept(int departmentId, FlightMockProject mockProject);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FlightMockProject Query(long id);
        /// <summary>
        /// 修改项目状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        bool UpdateState(long id, string state);
        /// <summary>
        /// 申请加入项目
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        bool ApplyJoin(int departmentId, long projectId);
        /// <summary>
        /// 编辑项目
        /// </summary>
        /// <param name="mockProject"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool Edit(FlightMockProject mockProject, out string msg);
        /// <summary>
        /// 根据关系查询项目
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        IEnumerable<FlightMockProject> QueryByMapCategory(int pageIndex, int pageSize, MapCategoryEnum category);
    }
}
