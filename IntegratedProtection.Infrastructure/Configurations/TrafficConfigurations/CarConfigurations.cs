namespace IntegratedProtection.Infrastructure.Configurations.TrafficConfigurations;

public class CarConfigurations : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.Property(p => p.Number)
            .HasMaxLength(100);

        builder.Property(c => c.Letters)
            .HasMaxLength(100);

    }
}
