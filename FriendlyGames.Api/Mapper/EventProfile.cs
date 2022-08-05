using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.Domain.Models;

namespace FriendlyGames.Api.Mapper;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventCreateDto>().ReverseMap();
        CreateMap<Event, EventDto>().ReverseMap();
    }
}