using AutoMapper;
using MockServer.Core.Domain;
using MockServer.Core.Domain.TCFlyMock;
using MockServer.Web.Areas.Users.Models;
using MockServer.Web.Models;
using System;

namespace MockServer.Web.App_Start.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            var map = CreateMap<LyOAuthUserInfo, UserInfoViewModel>();
            //反转映射
            map.ReverseMap();
            //指定映射
            map.ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department));
            var mapUserSelect = CreateMap<FlightMockUser, UserSelectViewModel>();
        }
    }
}