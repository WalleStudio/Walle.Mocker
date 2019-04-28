using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MockServer.Core.ConfigSection
{
	public class LyOAuthConfigSection : ConfigurationSection
	{
		public static LyOAuthConfigSection Config
		{
			get
			{
				return ConfigurationManager.GetSection("LyOAuthConfigSection") as LyOAuthConfigSection;
			}
		}

		//常量,字段名
		private const string field_ApplyTokenRedirectUri = "ApplyTokenRedirectUri";
		private const string field_StateApplyForCodeUri = "StateApplyForCodeUri";
		private const string field_CodeApplyForTokenUri = "CodeApplyForTokenUri";
		private const string field_SSOLogoutUri = "SSOLogoutUri";
		private const string field_GetUserInfoByTokenUri = "GetUserInfoByTokenUri";

		private const string field_Scope = "Scope";
		private const string field_ResponseType = "ResponseType";
		private const string field_ClientId = "ClientId";
		private const string field_ClientSecret = "ClientSecret";
		private const string field_GrantType = "GrantType";

		private const string field_AccessToken = "AccessToken";
		private const string field_UserName = "UserName";
		private const string field_Department = "Department";
		private const string field_WebRootPath = "WebRootPath";


		#region
		/// <summary>
		/// 登录成功,接收鉴权码的地址
		/// </summary>
		[ConfigurationProperty(field_ApplyTokenRedirectUri, IsRequired = true,
			DefaultValue = "http://flightadmin.17usoft.com/mock/0Auth/LyOAuthCodeCallBack")]
		public string ApplyTokenRedirectUri
		{
			get
			{
				return this[field_ApplyTokenRedirectUri] as string;
			}
		}

		/// <summary>
		/// 申请鉴权码的地址
		/// </summary>
		[ConfigurationProperty(field_StateApplyForCodeUri, IsRequired = false,
			DefaultValue = "http://tccommon.17usoft.com/oauth/authorize")]
		public string StateApplyForCodeUri
		{
			get
			{
				return this[field_StateApplyForCodeUri] as string;
			}
		}

		/// <summary>
		/// 通过鉴权码申请token的地址
		/// </summary>
		[ConfigurationProperty(field_CodeApplyForTokenUri, IsRequired = false,
			DefaultValue = "http://tccommon.17usoft.com/oauth/token")]
		public string CodeApplyForTokenUri
		{
			get
			{
				return this[field_CodeApplyForTokenUri] as string;
			}
		}

		/// <summary>
		/// SSO退出登录地址
		/// </summary>
		[ConfigurationProperty(field_SSOLogoutUri, IsRequired = false,
			DefaultValue = "http://tccommon.17usoft.com/oauth/logout")]
		public string SSOLogoutUri
		{
			get
			{
				return this[field_SSOLogoutUri] as string;
			}
		}

		[ConfigurationProperty(field_GetUserInfoByTokenUri, IsRequired = false,
			DefaultValue = "http://tccommon.17usoft.com/oauth/rs/getuserinfo")]
		public string GetUserInfoByTokenUri
		{
			get
			{
				return this[field_GetUserInfoByTokenUri] as string;
			}
		}

		/// <summary>
		/// Scope [默认read]
		/// </summary>
		[ConfigurationProperty(field_Scope, IsRequired = false,
			DefaultValue = "read")]
		public string Scope
		{
			get
			{
				return this[field_Scope] as string;
			}
		}

		/// <summary>
		/// ResponseType [默认code]
		/// </summary>
		[ConfigurationProperty(field_ResponseType, IsRequired = false,
			DefaultValue = "code")]
		public string ResponseType
		{
			get
			{
				return this[field_ResponseType] as string;
			}
		}

		/// <summary>
		/// ClientId ,必填
		/// </summary>
		[ConfigurationProperty(field_ClientId, IsRequired = true,
			DefaultValue = "")]
		public string ClientId
		{
			get
			{
				return this[field_ClientId] as string;
			}
		}


		/// <summary>
		/// ClientSecret ,必填
		/// </summary>
		[ConfigurationProperty(field_ClientSecret, IsRequired = true,
			DefaultValue = "")]
		public string ClientSecret
		{
			get
			{
				return this[field_ClientSecret] as string;
			}
		}

		/// <summary>
		/// 模式 ,默认使用, 鉴权码模式:authorization_code
		/// </summary>
		[ConfigurationProperty(field_GrantType, IsRequired = false,
			DefaultValue = "authorization_code")]
		public string GrantType
		{
			get
			{
				return this[field_GrantType] as string;
			}
		}

		[ConfigurationProperty(field_AccessToken, IsRequired = false, DefaultValue = "access_token")]
		public string AccessToken
		{
			get
			{
				return this[field_AccessToken] as string;
			}
		}

		[ConfigurationProperty(field_UserName, IsRequired = false, DefaultValue = "username")]
		public string UserName
		{
			get
			{
				return this[field_UserName] as string;
			}
		}

		[ConfigurationProperty(field_Department, IsRequired = false, DefaultValue = "department")]
		public string Department
		{
			get
			{
				return this[field_Department] as string;
			}
		}

		[ConfigurationProperty(field_WebRootPath, IsRequired = false, DefaultValue = "/")]
		public string WebRootPath
		{
			get
			{
				return this[field_WebRootPath] as string;
			}
		}

		#endregion

	}
}
