using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MockServer.Common.External
{
    public static class NameValueExt
    {
        public static IDictionary<string, string[]> ToDictionary(this NameValueCollection source)
        {
            Dictionary<string, string[]> result = new Dictionary<string, string[]>();
            if (source != null && source.AllKeys != null && source.AllKeys.Any())
            {
                foreach (var item in source.AllKeys)
                {
                    var key = item;
                    if (key != null)
                    {
                        var values = source.GetValues(key);
                        if (values != null && values.Any())
                        {
                            result.Add(key, values);
                        }
                    }

                }
            }
            return result;
        }
    }
}
