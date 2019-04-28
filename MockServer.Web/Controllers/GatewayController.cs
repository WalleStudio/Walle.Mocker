using MockServer.Common.External;
using MockServer.Common.Logger;
using MockServer.Core.Biz.Rules;
using MockServer.Core.Domain.TCFlyMock;
using MockServer.Web.Controllers.Filter;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace MockServer.Web.Controllers
{
    public class GatewayController : ApiController
    {
        public IFlightMockMatchBiz FlightMockMatchBiz { get; set; }

        private SkyNetMarker marker = new SkyNetMarker("ApiController", "Gateway", "Mock");

        [AcceptVerbs("POST", "GET")]
        [MockLogFilter]
        public ResponseMessageResult Mock()
        {
            try
            {
                var rule = new FlightMockMatchRule();
                var url = HttpContext.Current.Request.GetRequestUrl();
                if (HttpContext.Current.Request.HttpMethod == "GET")
                {
                    if (url.Contains('?'))
                    {
                        rule.Url = url.Split('?')[0];
                        rule.RequestBody = "?" + url.Split('?')[1];
                    }
                    else
                    {
                        rule.Url = url;
                        rule.RequestBody = string.Empty;
                    }
                }
                else
                {
                    rule.Url = url;
                    rule.RequestBody = Request.Content.ReadAsStringAsync().Result;
                }
                rule.RequestMethod = Request.Method.Method;
                var result = FlightMockMatchBiz.Match(rule);
                if (result != null && result.Id > 0)
                {
                    var responseMsg = this.Request.CreateResponse();
                    var parsedText = RazorParse(result.ResponseTemplate.ResponseBody);
                    responseMsg.Content = new StringContent(parsedText, System.Text.Encoding.UTF8, result.ResponseTemplate.ContentType);
                    responseMsg.Headers.TryAddWithoutValidation("Content-Type", result.ResponseTemplate.ContentType);
                    foreach (var head in result.ResponseTemplate.RespHeaders)
                    {
                        responseMsg.Headers.TryAddWithoutValidation(head.Name, head.Value);
                    }
                    responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue(result.ResponseTemplate.ContentType);
                    var res = this.ResponseMessage(responseMsg);
                    return res;
                }
                else
                {
                    var responseMsg = this.Request.CreateResponse();
                    responseMsg.Content = new StringContent(string.Empty);
                    responseMsg.StatusCode = HttpStatusCode.NoContent;
                    responseMsg.Headers.Clear();
                    var res = this.ResponseMessage(responseMsg);
                    return res;
                }
            }
            catch (Exception ex)
            {
                SkyNetLogger.LogError(marker, "mock接口异常", ex);
                var responseMsg = this.Request.CreateResponse();
                responseMsg.Content = new StringContent(string.Empty);
                responseMsg.StatusCode = HttpStatusCode.NoContent;
                responseMsg.Headers.Clear();
                var res = this.ResponseMessage(responseMsg);
                return res;
            }
        }

        private string RazorParse(string template)
        {
            var newLine = Environment.NewLine;
            var usingText = $"@using Mock {newLine}";
            var text = usingText + template;
            NameValueCollection data = new NameValueCollection();
            data.Add("DateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            string result = Razor.Parse(text, data);
            return result;
        }
    }
}