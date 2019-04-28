using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mock
{
    public class MockHelp
    {

        public static string GetRandStr(int length= 6)
        {
            var result = Guid.NewGuid().ToString("N").Substring(0, length);
            return result;
        }

    }
}