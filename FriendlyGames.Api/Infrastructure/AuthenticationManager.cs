using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FriendlyGames.Api.Dtos;
using FriendlyGames.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FriendlyGames.Api.Infrastructure;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApiUser> _userManager;
    private ApiUser _user = null!;

    public AuthenticationManager(UserManager<ApiUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> CreateJwtToken()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    public async Task<bool> ValidateApiUser(LoginApiUserDto userDto)
    {
        _user = await _userManager.FindByEmailAsync(userDto.Email);

        return _user != null && await _userManager.CheckPasswordAsync(_user, userDto.Password);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var issuer = jwtSettings.GetSection("Issuer").Value;
        var audience = jwtSettings.GetSection("Audience").Value;
        var lifetime = Convert.ToDouble(jwtSettings.GetSection("Lifetime").Value);
        var expires = DateTime.Now.AddMinutes(lifetime);

        var token = new JwtSecurityToken(
            issuer,
            audience,
            expires: expires,
            claims: claims,
            signingCredentials: signingCredentials
        );

        return token;
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new("userEmail", _user.Email),
            new("id", _user.Id),
            new("firstName", _user.FirstName),
            new("lastName", _user.LastName)
        };

        var roles = await _userManager.GetRolesAsync(_user);

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        return claims;
    }

    private static SigningCredentials GetSigningCredentials()
    {
        var key = Environment.GetEnvironmentVariable("FRIENDLYGAMES_KEY");
        var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key ?? throw new InvalidOperationException()));
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
}