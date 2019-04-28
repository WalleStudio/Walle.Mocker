using AutoMapper;
using MockServer.Web.App_Start.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MockServer.Web.App_Start.AutoMapper
{
    public static class AutoMapperConfig
    {
        /// <summary>
        /// 初始化AutoMapper配置
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                Core2ModelMapper.Initialize(cfg);
            });
        }
    }
}