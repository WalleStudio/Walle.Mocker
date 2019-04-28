using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockServer.Web.App_Start.AutoMapper.Profiles
{
    public static class Core2ModelMapper
    {
        internal static void Initialize(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<UserProfile>();
            cfg.AddProfile<ProjectProfile>();
        }
    }
}