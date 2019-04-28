using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Domain.TCFlyMock
{
    public class FlightMockMatchUrl
    {
        public long Id { get; set; } = 0;
        public string Url { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
