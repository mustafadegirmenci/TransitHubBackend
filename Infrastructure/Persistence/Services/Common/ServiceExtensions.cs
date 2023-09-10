using Application.Repositories;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        services.AddTransient<IAuthService, AuthService>();
    }
}