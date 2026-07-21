using AvangardQManagement.Application.Common.Interfaces;
using AvangardQManagement.Domain.Interfaces;
using AvangardQManagement.Infrastructure.ApplicationDbContext;
using AvangardQManagement.Infrastructure.Repositories;
using AvangardQManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AvangardDbContext>(options =>
        {
            options.UseNpgsql(dbConnection, b => b.MigrationsAssembly("AvangardQManagement.Infrastructure"));
        });


        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IReceptionRepository, ReceptionRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<AvangardDbContext>());

        services.AddTransient<IQueueNotificationService, QueueNotificationService>();




        return services;
    }
}
