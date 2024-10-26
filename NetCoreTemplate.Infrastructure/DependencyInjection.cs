using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreTemplate.Application.Abstractions.Clock;
using NetCoreTemplate.Application.Abstractions.Data;
using NetCoreTemplate.Application.Abstractions.Email;
using NetCoreTemplate.Domain.Abstractions;
using NetCoreTemplate.Domain.Users;
using NetCoreTemplate.Infrastructure.Clock;
using NetCoreTemplate.Infrastructure.Data;
using NetCoreTemplate.Infrastructure.Repositories;

namespace NetCoreTemplate.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        var connectionString = configuration.GetConnectionString("Database")
             ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        #region Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IVehiculoRepository, VehiculoRepository>();
        //services.AddScoped<IAlquilerRepository, AlquilerRepository>();
        #endregion

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        return services;
    }

}