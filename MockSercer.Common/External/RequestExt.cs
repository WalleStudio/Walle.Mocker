using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MockServer.Common.External
{
    public static class RequestExt
    {
        public static string GetRequestMimeType(this HttpRequestBase request)
        {
            var reqContentType = request.ContentType;
            return reqContentType;
        }
        public static string GetRequestString(this HttpRequestBase request)
        {
            try
            {
                var reqContentStr = string.Empty;
                byte[] byts = new byte[request.InputStream.Length];
                request.InputStream.Read(byts, 0, byts.Length);
                reqContentStr = System.Text.Encoding.UTF8.GetString(byts);
                return reqContentStr;
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string GetRequestUrl(this HttpRequestBase request)
        {
            var rawUrl = request.RawUrl;
            var localUrl = rawUrl.Split('?')[0];
            var reqUrl = rawUrl.Replace(localUrl, "").Replace("?url=", "");
            return reqUrl;
        }

        public static string GetResponseString(this HttpResponseBase response)
        {
            try
            {
                response.Flush();
                var reqContentStr = string.Empty;
                byte[] byts = new byte[response.OutputStream.Length];
                response.OutputStream.Read(byts, 0, byts.Length);
                reqContentStr = System.Text.Encoding.UTF8.GetString(byts);
                return reqContentStr;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string GetRequestMimeType(this HttpRequest request)
        {
            var reqContentType = request.ContentType;
            return reqContentType;
        }
        public static string GetRequestString(this HttpRequest request)
        {
            try
            {
                var reqContentStr = string.Empty;
                byte[] byts = new byte[request.InputStream.Length];
                request.InputStream.Read(byts, 0, byts.Length);
                reqContentStr = System.Text.Encoding.UTF8.GetString(byts);
                return reqContentStr;
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string GetRequestUrl(this HttpRequest request)
        {
            var rawUrl = request.RawUrl;
            var localUrl = rawUrl.Split('?')[0];
            var reqUrl = rawUrl.Replace(localUrl, "").Replace("?url=", "");
            return reqUrl;
        }

        public static string GetResponseString(this HttpResponse response)
        {
            try
            {
                response.Flush();
                var reqContentStr = string.Empty;
                byte[] byts = new byte[response.OutputStream.Length];
                response.OutputStream.Read(byts, 0, byts.Length);
                reqContentStr = System.Text.Encoding.UTF8.GetString(byts);
                return reqContentStr;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
