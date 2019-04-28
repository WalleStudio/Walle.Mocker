using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Domain.TCFlyMock
{
    public class FlightMockRespHeader
    {
        public long Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
