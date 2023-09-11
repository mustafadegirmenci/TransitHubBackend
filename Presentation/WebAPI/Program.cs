using System.Reflection;
using Application.Features.Authorization.Register;
using Persistence.Services.Common;

namespace WebAPI;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);        

        builder.Services.ConfigureServices(builder.Configuration);
        builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(RegisterHandler))));

        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        
        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();
        app.Run();
    }
}