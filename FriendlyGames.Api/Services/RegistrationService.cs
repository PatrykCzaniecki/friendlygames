using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.Api.Services.Interfaces;
using FriendlyGames.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.Api.Services;

public class RegistrationService : IRegistrationService
{
    private readonly FriendlyGamesDbContext _dbContext;
    private readonly IMapper _mapper;

    public RegistrationService(FriendlyGamesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IList<RegistrationDto>> GetRegistrations(int eventId, int userId, int registrationCategoryId)
    {
        var registrations = await (_dbContext.Registrations ?? throw new InvalidOperationException())
            .Include(x => x.EventId == eventId)
            .ToListAsync();
        return _mapper.Map<IList<RegistrationDto>>(registrations);
    }
}