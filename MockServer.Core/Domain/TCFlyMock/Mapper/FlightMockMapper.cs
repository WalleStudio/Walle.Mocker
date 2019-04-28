using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Domain.TCFlyMock.Mapper
{
    /// <summary>
    /// 对象映射关系
    /// </summary>
    public class FlightMockMapper
    {
        public long Id { get; set; } = 0;
        public long KeyId { get; set; } = 0;
        public long ValueId { get; set; } = 0;
        public string Category { get; set; } = string.Empty;
        public DateTime CreateTime { get; set; } = new DateTime(1900, 1, 1);
    }
}
