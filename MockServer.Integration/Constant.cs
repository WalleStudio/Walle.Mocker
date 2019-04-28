
namespace MockServer.Integration
{
	public static class Constant
	{
		/// <summary>
		/// 企业QQ相关需要使用的配置
		/// </summary>
		public static class EnterpriseQQ
		{
			public static readonly string EnterpriseQQUrl = "http://tceqqapi.17usoft.com/interface/Service.ashx";
			public static readonly string AccountKey = "flight.workbench";
			public static readonly string AccountSecret = "d6d46902-2610-4a18-ab57-5e23621d1762";
		}

		/// <summary>
		/// 天梯持续集成系统
		/// </summary>
		public static class SkyLadder
		{
			public static readonly string HostUrl = "http://tianti.17usoft.com/skyladder-web/";

			/// <summary>
			/// 所有post请求接口需要这个token,部分get接口: openapi/projects ,openapi/groups,openapi/servers 用.
			/// </summary>
			public static readonly string Token = "d56f775d-b6c7-485a-b592-c3b6983c386b";
		}
	}
}
