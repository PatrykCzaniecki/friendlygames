using FriendlyGames.Api.Dtos;

namespace FriendlyGames.Api.Infrastructure;

public interface IAuthenticationManager
{
    Task<bool> ValidateApiUser(LoginApiUserDto userDto);
    Task<string> CreateJwtToken();
}