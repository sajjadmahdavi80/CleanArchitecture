using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Abstractions.Contexts.Commands;
using Infrastructure.Repository.RelationalDbs.Commands;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using Microsoft.Extensions.Configuration;
using Application.Common.Abstractions.Contexts.Queries;
using Infrastructure.Repository.RelationalDbs.Queries;
using Application.Users.Repositories.Commands;
using Infrastructure.Repository.RelationalDbs.Commands.Users;
using Application.Common.Abstractions.UnitOfWork.Commands;
using Infrastructure.UnitOfWork.Commands;
using Application.Users.Repositories.Queries;
using Infrastructure.Repository.RelationalDbs.Queries.Users;
using Application.Common.Abstractions.UnitOfWork.Query;
using Infrastructure.UnitOfWork.Queries;


namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        //services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();


        services.AddScoped<ICommandDbContext>(provider => provider.GetRequiredService<CommandDbContext>());
        services.AddDbContext<CommandDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CallCenterSupervisor_Db"),
            builder => builder.MigrationsAssembly(typeof(CommandDbContext).Assembly.FullName));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            // options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });

        services.AddScoped<IQueryDbContext>(provider => provider.GetRequiredService<QueryDbContext>());
        services.AddDbContext<QueryDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CallCenterSupervisor_Db"),
            builder => builder.MigrationsAssembly(typeof(QueryDbContext).Assembly.FullName));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            // options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });

        services.AddScoped<ICommandUserRepository, CommandUserRepository>();
        services.AddScoped<IQueryUserRepository, QueryUserRepository>();



        services.AddScoped<ICommandUnitOfWork, CommandUnitOfWork>();
        services.AddScoped<IQueryUnitOfWork, QueryUnitOfWork>();


        return services;
    }
}
