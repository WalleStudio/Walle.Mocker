﻿using AutoMapper;
using MockServer.Core.Domain.TCFlyMock;
using MockServer.Web.Areas.Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockServer.Web.App_Start.AutoMapper.Profiles
{
    public class MockSystemProfile : Profile
    {
        public MockSystemProfile()
        {
            CreateMap<ProjectAddViewModel, FlightMockProject>();
        }
    }
}