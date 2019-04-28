using MockServer.Core.Biz;
using MockServer.Core.ConfigSection;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web;

namespace MockServer.Biz.LyOAuth
{
	public class LyOAuthBiz : ILyOAuthBiz
	{
		private LyOAuthConfigSection config = null;

		public LyOAuthConfigSection Config
		{
			get
			{
				if (config == null)
				{
					config = LyOAuthConfigSection.Config;
				}
				return config;
			}
		}

		public string GetUserInfo(string token)
		{
			var param = new NameValueCollection();
			param[Config.AccessToken] = token;
			return PostRequest(Config.GetUserInfoByTokenUri, param);
		}

		public string PostRequest(string url, NameValueCollection param)
		{
			var webClient = new WebClient();
			webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
			byte[] responseData = webClient.UploadValues(url, "POST", param);
			return Encoding.UTF8.GetString(responseData);
		}

		public string GenerateLoginUrl(string returnUri, string state)
		{
			var fullUri = new StringBuilder();
			fullUri.Append(Config.StateApplyForCodeUri)
				.Append("?response_type=").Append(Config.ResponseType)
				.Append("&scope=").Append(Config.Scope)
				.Append("&client_id=").Append(Config.ClientId)
				.Append("&redirect_uri=").Append(HttpUtility.UrlEncode(Config.ApplyTokenRedirectUri, Encoding.UTF8))
				.Append("&state=").Append(state)
				.Append("&return_uri=").Append(HttpUtility.UrlEncode(returnUri, Encoding.UTF8));
			return fullUri.ToString();

		}

		public string GetToken(string code)
		{
			var param = new NameValueCollection();
			param["client_id"] = Config.ClientId;
			param["client_secret"] = Config.ClientSecret;
			param["redirect_uri"] = Config.ApplyTokenRedirectUri;
			param["code"] = code;
			param["grant_type"] = Config.GrantType;
			//根据Code申请Token
			var result = PostRequest(Config.CodeApplyForTokenUri, param);
			return result;
		}
	}
}
