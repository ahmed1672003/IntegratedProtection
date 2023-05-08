namespace IntegratedProtection.Application;
public static class ApplicationDependencies
{
    public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
    {
        services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
