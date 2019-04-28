using MockServer.Common.Logger;
using MockServer.Core.Biz;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MockServer.Web.Controllers
{
    [AllowAnonymous]
	public class OAuthController : Controller
	{
		private ILyOAuthBiz LyOAuthBiz { get; set; }

		public OAuthController(ILyOAuthBiz LyOAuthBiz)
		{
			this.LyOAuthBiz = LyOAuthBiz;
		}

		/// <summary>
		/// 授权登录回调方法
		/// </summary>
		/// <param name="state"></param>
		/// <param name="code"></param>
		/// <returns></returns>
		public ActionResult LyOAuthCodeCallBack(string state, string code, string returnUri)
		{
			try
			{
				var request = System.Web.HttpContext.Current.Request;
				var stateCookie = request.Cookies["state"];

				//判断State是否一致
				if (stateCookie != null && stateCookie.Value.Equals(state))
				{
					stateCookie.Expires = DateTime.Now.AddDays(-1);
					stateCookie.Path = "";
					Response.AppendCookie(stateCookie);
					var result = LyOAuthBiz.GetToken(code);
					var value = JObject.Parse(result);
					var token = value[LyOAuthBiz.Config.AccessToken];
					if (token != null)
					{
						//拿着code去获取token
						var cookie = new HttpCookie(LyOAuthBiz.Config.AccessToken, token.ToString())
						{
							//cookie过期时间固定设置为12小时，与token过期时间一致
							Expires = DateTime.Now.AddHours(12),
							Path = LyOAuthBiz.Config.WebRootPath
						};
						Response.AppendCookie(cookie);
						if (string.IsNullOrEmpty(returnUri))
						{
							return RedirectToAction("Index", "Home", new { Area = "" });
						}
						return RedirectPermanent(returnUri);

					}
					ViewBag.error = "鉴权码错误"; //鉴权码错误
					return View("Error");
				}
				ViewBag.error = "状态码错误,可能存在伪装请求.";
				return View("Error");
			}
			catch (Exception ex)
			{
				SkyNetLogger.LogError(new SkyNetMarker("OAuth", "LyOAuthCodeCallBack", ""), "授权登录回调鉴权发生异常", ex);

				ViewBag.error = "验证鉴权码失败:" + ex.Message;
				return View("Error");
			}
		}

		/// <summary>
		/// 注销(清除Toekn、重定向到首页)
		/// </summary>Z
		public ActionResult LogOut()
		{
			try
			{   //本系统也要退出
				FormsAuthentication.SignOut();
				//SSO 退出
				var fullLogoutUri = new StringBuilder().Append(LyOAuthBiz.Config.SSOLogoutUri);
				var cookies = HttpContext.Request.Cookies[LyOAuthBiz.Config.AccessToken];
				if (cookies != null)
				{
					fullLogoutUri.Append("?").Append("access_token").Append("=").Append(cookies.Value);
					cookies.Expires = DateTime.Now.AddDays(-1);
					cookies.Path = LyOAuthBiz.Config.WebRootPath;
					Response.Cookies.Add(cookies);
					Request.Cookies.Remove("access_token");
				}
				//跳转到登陆页
				return Redirect(fullLogoutUri.ToString());
			}
			catch (Exception ex)
			{
				SkyNetLogger.LogError(new SkyNetMarker("OAuth", "LyOAuthCodeCallBack", ""), " 注销(清除Toekn、重定向到首页)发生异常", ex);
				ViewBag.error = "登出失败:" + ex.Message;
				return View("Error");
			}
		}
	}
}