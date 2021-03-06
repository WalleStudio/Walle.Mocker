﻿using MockServer.Core.Dal.TCFlyMock;
using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TCBase.Data;
using MockServer.Core.Domain.TCFlyMock.Enums;

namespace MockServer.Dal.TCFlyMock
{
    public class FlightMockProjectDal : DalClient, IFlightMockProjectDal
    {
        #region Private Method
        private string GetSqlWhere(FlightMockProject mockProject)
        {
            string sql = string.Empty;
            if (!string.IsNullOrWhiteSpace(mockProject.Owner))
            {
                sql += $"  AND Owner='{mockProject.Owner}'";
            }
            if (!string.IsNullOrWhiteSpace(mockProject.State))
            {
                sql += $" AND State='{mockProject.State}'";
            }
            if (!string.IsNullOrWhiteSpace(mockProject.Name))
            {
                sql += $" AND Name='{mockProject.Name}'";
            }
            if (!string.IsNullOrWhiteSpace(mockProject.SkyEye))
            {
                sql += $" AND SkyEye='{mockProject.SkyEye}'";
            }
            return sql;
        }
        #endregion

        public bool Update(FlightMockProject mockProject)
        {
            var result = DataClient.Update(mockProject);
            return result;
        }

        public long Add(FlightMockProject mockProject)
        {
            var result = DataClient.Add(mockProject);
            return result;
        }

        public IEnumerable<FlightMockProject> QueryByPage(int pageIndex, int pageSize, List<long> ids, FlightMockProject mockProject)
        {
            string sqlWhere = GetSqlWhere(mockProject);
            string idsStr = string.Join(",", ids.ToArray());
            string sql = $"select * from FlightMockProject where Id in({idsStr}){sqlWhere}";
            //数据分页默认0是第一页，这里进行减1处理
            var result = DataClient.QueryByPage<FlightMockProject>(sql, pageIndex - 1, pageSize);
            return result;
        }

        public IEnumerable<FlightMockProject> QueryByPage(int pageIndex, int pageSize, FlightMockProject mockProject)
        {
            string sqlWhere = GetSqlWhere(mockProject);
            string sql = $"select * from FlightMockProject where 1=1 {sqlWhere} order by Id desc";
            //数据分页默认0是第一页，这里进行减1处理
            var result = DataClient.QueryByPage<FlightMockProject>(sql, pageIndex - 1, pageSize);
            return result;
        }

        public int QueryCount(FlightMockProject mockProject)
        {
            string sqlWhere = GetSqlWhere(mockProject);
            string sql = $"select count(1) from FlightMockProject where 1=1 {sqlWhere}";
            var result = DataClient.QueryScalar<int>(sql);
            if (result.HasValue)
            {
                return result.Value;
            }
            return 0;
        }

        public int QueryCount(List<long> ids, FlightMockProject mockProject)
        {
            string idsStr = string.Join(",", ids.ToArray());
            string sqlWhere = GetSqlWhere(mockProject);
            string sql = $"select count(1) from FlightMockProject where Id in({idsStr}){sqlWhere}";
            var result = DataClient.QueryScalar<int>(sql);
            if (result.HasValue)
            {
                return result.Value;
            }
            return 0;
        }

        public int QueryCountNonIds(List<long> ids, FlightMockProject mockProject)
        {
            string idsStr = string.Join(",", ids.ToArray());
            string sqlWhere = GetSqlWhere(mockProject);
            string sql = $"select count(1) from FlightMockProject where Id not in({idsStr}){sqlWhere}";
            var result = DataClient.QueryScalar<int>(sql);
            if (result.HasValue)
            {
                return result.Value;
            }
            return 0;
        }

        public IEnumerable<FlightMockProject> QueryByPageNonIds(int pageIndex, int pageSize, List<long> ids, FlightMockProject mockProject)
        {
            string sqlWhere = GetSqlWhere(mockProject);
            string idsStr = string.Join(",", ids.ToArray());
            string sql = $"select * from FlightMockProject where Id not in({idsStr}){sqlWhere}";
            //数据分页默认0是第一页，这里进行减1处理
            var result = DataClient.QueryByPage<FlightMockProject>(sql, pageIndex - 1, pageSize);
            return result;
        }

        public FlightMockProject Query(long id)
        {
            var result = DataClient.GetEntityById<FlightMockProject>(id);
            return result;
        }

        public bool Update(long id, string state)
        {
            string sql = "update FlightMockProject set State=@State where Id=@Id";
            var count = DataClient.ExecuteWriteSql(sql, new { Id = id, State = state });
            return count > 0;
        }

        public FlightMockProject Query(string name)
        {
            string sql = "select * from FlightMockProject where Name=@name";
            var result = DataClient.Query<FlightMockProject>(sql, new { name = name });
            if (result != null && result.Any())
            {
                return result.First();
            }
            return null;
        }
    }
}
