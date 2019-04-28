using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Common.External
{
	public static class StringExt
	{
		public static bool IsNullOrEmpty(this string text)
		{
			return string.IsNullOrEmpty(text);
		}
	}
}
