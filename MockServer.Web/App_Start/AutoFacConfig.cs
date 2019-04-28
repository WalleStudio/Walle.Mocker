using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MockServer.Common.Logger;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;


namespace MockServer.Web.App_Start
{
    public class AutoFacConfig
	{
		public static void Register(HttpConfiguration config)
		{
			//SkyNetLogger
			var marker = new SkyNetMarker("AutoFac", "Config", "Register");
			Stopwatch watch = new Stopwatch();
			watch.Start();
			try
			{
				var builder = new ContainerBuilder();

				var bizPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Bin\MockServer.Biz.dll");
				var dalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Bin\MockServer.Dal.dll");
				var integrationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Bin\MockServer.Integration.dll");


				if (!File.Exists(bizPath))
				{
					throw new FileNotFoundException("业务逻辑实现层dll不存在", bizPath);
				}

				if (!File.Exists(dalPath))
				{
					throw new FileNotFoundException("数据访问实现层dll不存在", dalPath);
				}

				if (!File.Exists(integrationPath))
				{
					throw new FileNotFoundException("外部集成实现层dll不存在", integrationPath);
				}


				//WARNING: 根据命名约定来实现注入.
				//注册业务实现Business类
				var BusinessServices = Assembly.LoadFile(bizPath);
				RegisterType(builder, BusinessServices, "Biz");


				//注册外部集成Integration的实现类
				var Integrations = Assembly.LoadFile(integrationPath);
				RegisterType(builder, Integrations, "Integration");
				RegisterType(builder, Integrations, "Client");


				//注册数据访问Repostitory的实现类
				var Repositorys = Assembly.LoadFile(dalPath);
				RegisterType(builder, Repositorys, "Dal");

				//注册主项目的Controllers
				builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

                var container = builder.Build();
               config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			}
			catch (Exception ex)
			{
				SkyNetLogger.LogError(marker, "执行dll依赖注入容器时发生错误.", ex);
			}

			watch.Stop();
		}

		private static void RegisterType(ContainerBuilder builder, Assembly assembly, string endWith)
		{
			var types = assembly.GetTypes().Where(p => (p.Name.EndsWith(endWith)));
			foreach (var item in types)
			{
				Type[] interfaceTypes = item.GetInterfaces();
				if (interfaceTypes.Count() > 0)
				{
					foreach (var t in interfaceTypes)
					{
						if (t.Name.EndsWith(endWith))
						{
							builder.RegisterType(item).As(t);
						}
					}
				}
			}
		}
	}

}