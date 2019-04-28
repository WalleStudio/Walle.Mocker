using MockServer.Core.ConfigSection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockServer.Core.Biz
{
	public interface ILyOAuthBiz
	{
		LyOAuthConfigSection Config { get; }
		string GenerateLoginUrl(string returnUri, string state);
		string GetToken(string code);
		string GetUserInfo(string token);
		string PostRequest(string url, NameValueCollection param);
	}
}
