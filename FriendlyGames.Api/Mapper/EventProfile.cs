using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.Domain.Models;

namespace FriendlyGames.Api.Mapper;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventCreateUpdateDto>().ReverseMap();
        CreateMap<Event, EventUpdateDto>().ReverseMap();
        CreateMap<Registration, RegistrationDto>().ReverseMap();
        CreateMap<RegistrationCreateUpdateDto, Registration>().ReverseMap();
    }
}