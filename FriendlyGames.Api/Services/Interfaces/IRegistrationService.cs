using FriendlyGames.Api.Dtos;

namespace FriendlyGames.Api.Services.Interfaces;

public interface IRegistrationService
{
    Task<IList<RegistrationDto>> GetRegistrations(int eventId, int userId, int registrationCategoryId);
}