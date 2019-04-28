using MockServer.Common.External;
using MockServer.Common.Logger;
using MockServer.Core.Biz;
using MockServer.Core.Biz.Users;
using MockServer.Core.Domain;
using MockServer.Web.Models;
using System;
using System.Web;
using System.Web.Mvc;

using System.Web.Routing;


namespace MockServer.Web.Controllers.Filter
{
    public class OAuthorizeAttribute : AuthorizeAttribute
    {
        private ILyOAuthBiz LyOAuthBiz
        {
            get
            {
                return DependencyResolver.Current.GetService<ILyOAuthBiz>();
            }
        }

        private IFlightMockUserBiz FlightMockUserBiz
        {
            get
            {
                return DependencyResolver.Current.GetService<IFlightMockUserBiz>();
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                bool pass = false;
                var token = httpContext.Request.Cookies[LyOAuthBiz.Config.AccessToken];

                //没有获取到token
                if (token == null || string.IsNullOrEmpty(token.Value))
                {
                    httpContext.Response.StatusCode = 401;
                    pass = false;
                }

                //获取到token
                if (token != null && !string.IsNullOrEmpty(token.Value))
                {
                    var userinfostring = LyOAuthBiz.GetUserInfo(token.Value);
                    if (string.IsNullOrEmpty(userinfostring))
                    {
                        httpContext.Response.StatusCode = 403;
                        return false;
                    }
                    LyOAuthUserInfo userinfo = userinfostring.ToObject<LyOAuthUserInfo>();
                    //没有获取到用户信息
                    if (userinfo == null)
                    {
                        httpContext.Response.StatusCode = 401;
                        return false;
                    }
                    //得到用户信息
                    if (userinfo != null)
                    {
                        LyOAuthPrincipal principal = new LyOAuthPrincipal(userinfo);
                        httpContext.User = principal;
                        //进行验证action访问权限

                        FlightMockUserBiz.SyncUser(new Core.Domain.TCFlyMock.FlightMockUser {
                            DepartmentId = userinfo.DepartmentId,
                            WorkId = userinfo.WorkId,
                            UserName = userinfo.UserName,
                            UserId = userinfo.UserId,
                            Department = userinfo.Department
                        });
                        try
                        {
                            var routeData = httpContext.Request.RequestContext.RouteData;
                            var area = routeData.DataTokens["area"]?.ToString();
                            var controller = routeData.Values["controller"].ToString();
                            var action = routeData.Values["action"].ToString();

                            SkyNetLogger.LogInfo(new SkyNetMarker("Attributes", "OAuthAuthorize", "AuthorizeCore"),
                                $"用户:{principal.UserData.UserName}{principal.UserData.WorkId}访问了area:{area},controller:{controller},action:{action}");

                        }
                        catch (Exception ex) when (ex is NullReferenceException)
                        {
                            SkyNetLogger.LogError(new SkyNetMarker("Attributes", "OAuthAuthorize", "AuthorizeCore"), "进行用户访问权限验证发生错误", ex);
                            return false;
                        }
                        return true;
                    }
                }
                return pass;
            }
            catch (Exception ex)
            {
                SkyNetLogger.LogError(new SkyNetMarker("Attributes", "OAuthAuthorize", "AuthorizeCore"), "进行用户token验证发生错误", ex);
                return false;
            }

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            if (filterContext.HttpContext.Response.StatusCode == 401)
            {
                var returnUri = filterContext.HttpContext.Request.Url.ToString();
                // 用于防止跨站请求伪造（CSRF）攻击
                var state = Guid.NewGuid().ToString().Replace("-", "");
                var cookie = new HttpCookie("state", state)
                {
                    Path = LyOAuthBiz.Config.WebRootPath
                };
                HttpContext.Current.Response.AppendCookie(cookie);

                var redirectUrl = LyOAuthBiz.GenerateLoginUrl(returnUri, state);

                //对于js的请求, 返回json内容.
                if (filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.HttpContext.Request.ContentType == "application/json")
                {
                    JsonMessage message = new JsonMessage();
                    message.Message = "身份授权失败.";
                    message.Result = false;
                    message.Type = JsonMessage.MsgType.AccessDeny;
                    message.Data = redirectUrl;
                    filterContext.HttpContext.Response.ContentType = "application/json";
                    filterContext.HttpContext.Response.Write(message.ToJson());
                    //前端请麻烦使用MyMessager使用.
                }
                else
                {
                    filterContext.Result = new RedirectResult(redirectUrl);
                }
            }
            if (filterContext.HttpContext.Response.StatusCode == 403)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "AccessDenied", area = "" }));
            }
        }
    }
}