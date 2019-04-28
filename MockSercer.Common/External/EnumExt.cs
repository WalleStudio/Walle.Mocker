using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Common.External
{
    public static class EnumExtHelper
    {
        public static string GetEnumName(this Enum obj)
        {
            return obj.ToString();
        }

        public static int GetEnumValue(this Enum obj)
        {
            return obj.GetHashCode();
        }
    }
}
