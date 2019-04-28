using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Common
{
	/// <summary>
	/// Http请求帮助类
	/// </summary>
	public static class HttpRequestHelper
	{
		/// <summary>
		/// Http Get 请求并返回字符串, 如果失败则返回空
		/// </summary>
		/// <param name="url">请求地址</param>
		/// <returns>返回字符串</returns>
		public static string Get(string url)
		{
			var result = string.Empty;
			var client = new HttpClient();
			var response = client.GetAsync(url).Result;

			if (response.StatusCode == HttpStatusCode.OK)
			{
				result = response.Content.ReadAsStringAsync().Result;
			}
			return result;
		}

		public static string Post(string json, string url)
		{
			var result = string.Empty;
			var client = new HttpClient();
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			var response = client.PostAsync(url, content).Result;
			if (response.StatusCode == HttpStatusCode.OK)
			{
				result = response.Content.ReadAsStringAsync().Result;
			}
			return result;
		}



	}
}
