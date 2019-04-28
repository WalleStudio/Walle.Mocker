using MockServer.Common.External;
using MockServer.Common.Logger;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MockServer.Web.Controllers.Filter
{
    public class MockRequestHandler : DelegatingHandler
    {
        /// <summary>  
        /// 拦截请求  
        /// </summary>  
        /// <param name="request">请求</param>  
        /// <param name="cancellationToken">用于发送取消操作信号</param>  
        /// <returns></returns>  
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            NameValueCollection query = HttpUtility.ParseQueryString(request.RequestUri.Query);
            string RequestContent = request.Content.ReadAsStringAsync().Result;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            response.Content = new StringContent(response.Content.ReadAsStringAsync()?.Result);
            sw.Stop();

            var exeMs = sw.Elapsed.TotalMilliseconds;

            var newline = Environment.NewLine;
            SkyNetLogger.LogInfo($"请求:{query.ToJson()}{newline}{RequestContent}{newline}返回:{response.Content.ReadAsStringAsync().Result}耗时:{exeMs}");

            return response;
        }

        /// <summary>  
        /// 构造自定义HTTP响应消息  
        /// </summary>  
        /// <param name="error"></param>  
        /// <param name="code"></param>  
        /// <returns></returns>  
        private HttpResponseMessage SendError(string error, HttpStatusCode code)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(error);
            response.StatusCode = code;
            return response;
        }
    }
}