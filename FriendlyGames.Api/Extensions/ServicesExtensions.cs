using System.Text;
using FriendlyGames.DataAccess;
using FriendlyGames.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FriendlyGames.Api.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureAuthenticationAndIdentityManagement(this IServiceCollection services)
    {
        services.AddAuthentication();
        var builder = services.AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail = true);
        builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
        builder.AddEntityFrameworkStores<FriendlyGamesDbContext>().AddDefaultTokenProviders();
    }

    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("Jwt");
        var key = Environment.GetEnvironmentVariable("FRIENDLYGAMES_KEY");

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                ValidAudience = jwtSettings.GetSection("Audience").Value,
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key ?? throw new InvalidOperationException()))
            };
        });
    }
}