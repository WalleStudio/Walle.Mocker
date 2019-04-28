using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Domain.TCFlyMock.Mapper
{
    public enum MapCategoryEnum
    {
        /// <summary>
        /// 项目和规则
        /// </summary>
        Project2Rule,

        /// <summary>
        /// 规则和url, rule作为key
        /// </summary>
        MockRule2Url,

        /// <summary>
        /// 规则和返回实体
        /// </summary>
        MockRule2MockResp,

        /// <summary>
        /// 返回实体和返回头信息
        /// </summary>
        MockResp2MockRespHeader,

        /// <summary>
        /// 部门和项目
        /// </summary>
        Department2Project,

        ///// <summary>
        ///// 部门和项目初始化(待审核)
        ///// </summary>
        //Department2ProjectInit,

        /// <summary>
        /// 被删除的项目规则
        /// </summary>
        Project2RuleDelete
    }
}
