using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Common
{
	public static class Converter
	{
		/// <summary>
		/// 时间戳转化为时间
		/// </summary>
		/// <param name="timestamp"></param>
		/// <returns></returns>
		public static DateTime ParseTimestamp(long timestamp)
		{
			var length = timestamp.ToString().Length;
			if (length < 17)
			{
				long x = (long)Math.Pow(10, 17 - length);
				timestamp = timestamp * x;
			}
			DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			TimeSpan ts = new TimeSpan(timestamp);
			var result = dtStart.Add(ts);
			return result;
		}
	}
}
