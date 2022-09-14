using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.Domain.Models;

namespace FriendlyGames.Api.Mapper
{
    public class ApiUserProfile : Profile
    {
        public ApiUserProfile()
        {
            CreateMap<ApiUser, LoginApiUserDto>().ReverseMap();
            CreateMap<ApiUser, RegisterApiUserDto>().ReverseMap();
        }
    }
}
