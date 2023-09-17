using System.Security.Claims;
using System.Text;
using Application.Repositories.Entity;
using Application.Services;
using Domain.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.Context;
using Persistence.Repositories.Entity;

namespace Persistence.Services.Common;

public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("conn")));
        
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();

        services.AddTransient<IHashingService, HashingService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IAuthService, AuthService>();
        
        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();

        services.AddHttpContextAccessor();
        
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
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
            options.AddPolicy("CustomerPolicy", policy =>
                policy.RequireClaim(ClaimTypes.Role, "Customer"));
    
            options.AddPolicy("CompanyPolicy", policy =>
                policy.RequireClaim(ClaimTypes.Role, "Company"));
        });
    }
}