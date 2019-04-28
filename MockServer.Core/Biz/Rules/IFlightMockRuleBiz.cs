using MockServer.Core.Domain.TCFlyMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Biz.Rules
{
    public interface IFlightMockRuleBiz
    {
        long Create(FlightMockMatchRule rule);
  
        /// <summary>
        /// 软删除规则
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        long SoftDelete(int id);

        /// <summary>
        /// 激活
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Active(int id);

        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Frozen(int id);
    }
}
