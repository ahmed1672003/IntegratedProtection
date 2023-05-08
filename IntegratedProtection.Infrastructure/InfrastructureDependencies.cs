
namespace IntegratedProtection.Infrastructure;
public static class InfrastructureDependencies
{
    public static IServiceCollection
        RegisterInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IntegratedProtectionDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("IntegratedProtectionConnection"));
        });
        services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

        return services;
    }

}
