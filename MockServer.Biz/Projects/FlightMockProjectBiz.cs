using MockServer.Core.Biz.Projects;
using MockServer.Core.Dal.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MockServer.Core.Domain.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock.Enums;
using MockServer.Core.Dal.TCFlyMock.Mapper;
using MockServer.Core.Domain.TCFlyMock.Mapper;

namespace MockServer.Biz.Projects
{
    public class FlightMockProjectBiz : IFlightMockProjectBiz
    {
        private IFlightMockProjectDal FlightMockProjectDal { get; set; }
        private IFlightMockMapperDal FlightMockMapperDal { get; set; }
        public FlightMockProjectBiz(
            IFlightMockProjectDal FlightMockProjectDal,
            IFlightMockMapperDal FlightMockMapperDal)
        {
            this.FlightMockProjectDal = FlightMockProjectDal;
            this.FlightMockMapperDal = FlightMockMapperDal;
        }

        #region private method
        private bool Verify(FlightMockProject mockProject, out string msg)
        {
            FlightMockProject verifyModel = new FlightMockProject()
            {
                Name = mockProject.Name
            };
            msg = string.Empty;
            var result = FlightMockProjectDal.QueryCount(verifyModel);
            if (result > 0)
            {
                msg = "存在相同名字的项目!";
                return false;
            }
            return true;
        }
        #endregion

        public bool Create(FlightMockProject mockProject, int departmentId, out string msg)
        {
            msg = string.Empty;
            if (Verify(mockProject, out msg))
            {
                var count = FlightMockProjectDal.Add(mockProject);
                if (count > 0)
                {
                    Join(departmentId, count);
                    msg = "新建成功!等待管理员审核!";
                }
                else
                {
                    msg = "入库失败!";
                }
                return count > 0;
            }
            return false;
        }

        public bool Join(int departmentId, long projectId)
        {
            var result = FlightMockMapperDal.CreateMap(departmentId, projectId, MapCategoryEnum.Department2Project);
            return result > 0;
        }

        public IEnumerable<FlightMockProject> Query(FlightMockProject mockProject)
        {
            if (mockProject == null)
            {
                mockProject = new FlightMockProject();
            }
            if (mockProject.IsPage)
            {
                var result = FlightMockProjectDal.QueryByPage(mockProject.PageIndex, mockProject.PageSize, mockProject);
                return result;
            }
            //TODO:未分页的查询 待定
            return null;
        }

        public int QueryCount(FlightMockProject mockProject)
        {
            if (mockProject == null)
            {
                mockProject = new FlightMockProject();
            }
            var result = FlightMockProjectDal.QueryCount(mockProject);
            return result;
        }

        public IEnumerable<FlightMockProject> QueryByDept(int departmentId, FlightMockProject mockProject)
        {
            var valueIds = FlightMockMapperDal.QueryByKey(departmentId, MapCategoryEnum.Department2Project);
            if (valueIds != null && valueIds.Any())
            {
                if (mockProject.IsPage)
                {
                    var result = FlightMockProjectDal.QueryByPage(mockProject.PageIndex, mockProject.PageSize, valueIds.ToList(), mockProject);
                    foreach (var item in result)
                    {
                        if (mockProject.CurrentUser == item.Owner)
                        {
                            item.IsCanEdit = true;
                        }
                    }
                    return result;
                }
                //TODO:未分页的查询 待定
            }
            return null;
        }

        public int QueryCountByDept(int departmentId, FlightMockProject mockProject)
        {
            if (mockProject == null)
            {
                mockProject = new FlightMockProject();
            }
            var valueIds = FlightMockMapperDal.QueryByKey(departmentId, MapCategoryEnum.Department2Project);
            if (valueIds != null && valueIds.Any())
            {
                var result = FlightMockProjectDal.QueryCount(valueIds.ToList(), mockProject);
                return result;
            }
            return 0;
        }

        public IEnumerable<FlightMockProject> UnQueryByDept(int departmentId, FlightMockProject mockProject)
        {
            var valueIds = FlightMockMapperDal.QueryByKey(departmentId, MapCategoryEnum.Department2Project);
            IEnumerable<FlightMockProject> result = null;
            if (mockProject.IsPage)
            {
                if (valueIds != null && valueIds.Any())
                {
                    result = FlightMockProjectDal.QueryByPageNonIds(mockProject.PageIndex, mockProject.PageSize, valueIds.ToList(), mockProject);
                }
                else
                {
                    //查所有
                    result = FlightMockProjectDal.QueryByPage(mockProject.PageIndex, mockProject.PageSize, mockProject);
                }
                foreach (var item in result)
                {
                    //TODO:待优化-ybb
                    var ids = FlightMockMapperDal.QueryByValue(item.Id, MapCategoryEnum.Department2Project);
                    if (ids != null && ids.Any())
                    {
                        if (ids.Contains(departmentId))
                        {
                            item.IsApply = true;
                        }
                    }
                }
                return result;
            }
            //TODO:未分页的查询 待定
            return null;
        }

        public int UnQueryCountByDept(int departmentId, FlightMockProject mockProject)
        {
            if (mockProject == null)
            {
                mockProject = new FlightMockProject();
            }
            int result = 0;
            var valueIds = FlightMockMapperDal.QueryByKey(departmentId, MapCategoryEnum.Department2Project);
            if (valueIds != null && valueIds.Any())
            {
                result = FlightMockProjectDal.QueryCountNonIds(valueIds.ToList(), mockProject);
                return result;
            }
            //查所有
            result = FlightMockProjectDal.QueryCount(mockProject);
            return result;
        }

        public FlightMockProject Query(long id)
        {
            var result = FlightMockProjectDal.Query(id);
            return result;
        }

        public bool UpdateState(long id, string state)
        {
            return FlightMockProjectDal.Update(id, state);
        }

        public bool ApplyJoin(int departmentId, long projectId)
        {
            var result = FlightMockMapperDal.Query(departmentId, projectId, MapCategoryEnum.Department2Project);
            if (result != null)
            {
                return true;
            }
            var createResult = FlightMockMapperDal.CreateMap(departmentId, projectId, MapCategoryEnum.Department2Project);
            return createResult > 0;
        }

        public bool Edit(FlightMockProject mockProject, out string msg)
        {
            msg = string.Empty;
            var result = FlightMockProjectDal.Query(mockProject.Id);
            if (result != null)
            {
                if (mockProject.Name != result.Name)
                {
                    var project = FlightMockProjectDal.Query(mockProject.Name);
                    if (project != null)
                    {
                        msg = "编辑失败!存在相同名称的项目!";
                        return false;
                    }
                }
                result.Name = mockProject.Name;
                result.Url = mockProject.Url;
                result.Description = mockProject.Description;
                var updateResult = FlightMockProjectDal.Update(result);
                if (updateResult)
                {
                    msg = "编辑成功!";
                    return true;
                }
                else
                {
                    msg = "编辑失败!更新数据库失败!";
                    return false;
                }
            }
            msg = "项目不存在!请刷新!";
            return false;
        }

        public IEnumerable<FlightMockProject> QueryByMapCategory(int pageIndex, int pageSize, MapCategoryEnum category)
        {
            var result = FlightMockMapperDal.Query(category);
            if (result != null && result.Any())
            {
                return null;
            }
            return null;
        }
    }
}

