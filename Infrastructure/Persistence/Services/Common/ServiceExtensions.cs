using System.Text;
using Application.Repositories;
using Application.Services;
using Domain.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence.Services.Common;


public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("conn")));

        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IResponseRepository, ResponseRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();

        services.AddTransient<IHashingService, HashingService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IAuthService, AuthService>();
        
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.JwtSecret))
            };
        });
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("UserPolicy", policy =>
                policy.RequireClaim("role", "User"));
    
            options.AddPolicy("CompanyPolicy", policy =>
                policy.RequireClaim("role", "Company"));
        });
    }
}