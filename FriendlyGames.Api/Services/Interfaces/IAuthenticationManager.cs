using FriendlyGames.Api.Dtos;

namespace FriendlyGames.Api.Services;

public interface IAuthenticationManager
{
    Task<bool> ValidateApiUser(LoginApiUserDto userDto);
    Task<string> CreateJwtToken();
}