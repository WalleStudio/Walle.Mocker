using MockServer.Common.External;
using MockServer.Common.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace MockServer.Web.Controllers.Filter
{
    public class MockLogFilterAttribute : ActionFilterAttribute
    {

        private string logMessage = string.Empty;
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            var request = actionExecutedContext.Request;
            var response = actionExecutedContext.Response;

            var newLine = Environment.NewLine;
            logMessage += $"请求方式:{newLine}{request.Method}{newLine}";
            logMessage += $"请求地址:{newLine}{request.RequestUri}{newLine}";
            logMessage += $"请求内容:{newLine}{request.Content.ReadAsStringAsync().Result}{newLine}";
            logMessage += $"请求头信息:{newLine}{request.Content.Headers.ToJson()}{newLine}";

            logMessage += $"响应内容:{newLine}{response.Content.ReadAsStringAsync().Result}{newLine}";
            logMessage += $"响应头信息:{newLine}{response.Content.Headers.ToJson()}{newLine}";
            logMessage += $"状态码:{newLine}{response.StatusCode}{newLine}";

            SkyNetLogger.LogInfo(logMessage);
            logMessage = string.Empty;
        }
    }
}
