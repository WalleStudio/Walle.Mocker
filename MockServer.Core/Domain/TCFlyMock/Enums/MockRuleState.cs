using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Domain.TCFlyMock.Enums
{
    public enum MockRuleState
    {
        /// <summary>
        /// 激活状态
        /// </summary>
        Active = 1,
        /// <summary>
        /// 冻结状态
        /// </summary>
        Frozen = 2
    }
}
