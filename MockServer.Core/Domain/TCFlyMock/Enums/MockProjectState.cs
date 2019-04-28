using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Domain.TCFlyMock.Enums
{
    public enum MockProjectState
    {
        /// <summary>
        /// 初始化
        /// </summary>
        Initialize,
        /// <summary>
        /// 有效
        /// </summary>
        Valid,
        /// <summary>
        /// 无效
        /// </summary>
        Invalid
    }
}
