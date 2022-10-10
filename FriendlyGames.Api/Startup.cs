using System.Reflection;
using FriendlyGames.Api.Extensions;
using FriendlyGames.Api.Services;
using FriendlyGames.Api.Services.Interfaces;
using FriendlyGames.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace FriendlyGames.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<FriendlyGamesDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("MssqlConnection")).LogTo(Console.WriteLine,
                    new[] {DbLoggerCategory.Database.Command.Name}, LogLevel.Information)
                .EnableSensitiveDataLogging();
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<ICategoriesService, CategoriesService>();
        services.AddScoped<IAuthenticationManager, AuthenticationManager>();
        services.AddScoped<IRegistrationService, RegistrationService>();

        services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "FriendlyGames.Api", Version = "v1"});
        });

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        // Authentication & Identity Management
        services.ConfigureAuthenticationAndIdentityManagement();

        // JWT
        services.ConfigureJwt(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FriendlyGames.Api v1"));
        }

        app.UseCors();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}