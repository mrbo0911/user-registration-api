using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserRegistration.Application.Handlers.UserHandlers;
using UserRegistration.Domain.Interfaces;
using UserRegistration.Infrastructure.Persistence;
using UserRegistration.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure Services
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();

/// <summary>
/// Configures application services.
/// </summary>
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Configure InMemory Database Context
    builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite("Data Source=user_registration.db"));

    services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

    // Add Controllers & API Explorer
    services.AddControllers();
    services.AddEndpointsApiExplorer();

    // Add Swagger services
    builder.Services.AddSwaggerGen();

    // Register repository dependencies
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IOtpRepository, OtpRepository>();

    // Register MediatR for CQRS
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RegisterUserCommandHandler>());
}