using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
	public static class EnumerableExt
	{
		public static string ToArrayString<TSource>(this IEnumerable<TSource> source,char spliter)
		{
			var result = string.Empty;
			foreach (var item in source)
			{
				result += item.ToString() +spliter;
			}
			result = result.TrimEnd(spliter);
			return result;
		}
	}
}
