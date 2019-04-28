using MockServer.Common.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace MockServer.Core.Domain
{
	public class LyOAuthPrincipal : IPrincipal
	{
		private IIdentity _identity;
		private LyOAuthUserInfo _userInfo;
		private string _username = string.Empty;

		private FormsAuthenticationTicket _ticket = null;

		public LyOAuthPrincipal(LyOAuthUserInfo userinfo)
		{
			if (userinfo == null)
				throw new ArgumentNullException("userinfo");

			var username = userinfo.UserName;

			FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
			1,
			username,
			DateTime.Now,
			DateTime.Now.AddMinutes(30),
			false, userinfo.ToJson(),
			FormsAuthentication.FormsCookiePath);

			this._ticket = authTicket;
			this._identity = new FormsIdentity(authTicket);
			this._userInfo = userinfo;
			this._username = username;
		}

		public LyOAuthUserInfo UserData
		{
			get { return _userInfo; }
		}

		public IIdentity Identity
		{
			get { return _identity; }
		}

		public bool IsInRole(string role)
		{
			return true;
		}

	}
}
