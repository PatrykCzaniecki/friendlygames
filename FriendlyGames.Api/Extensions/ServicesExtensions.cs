using FriendlyGames.DataAccess;
using FriendlyGames.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace FriendlyGames.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        public static void ConfigureAuthenticationAndIdentityManagement(this IServiceCollection services)
        {
            services.AddAuthentication();
            var builder = services.AddIdentityCore<User>(q => q.User.RequireUniqueEmail = true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<FriendlyGamesDbContext>().AddDefaultTokenProviders();
        }
    }
}