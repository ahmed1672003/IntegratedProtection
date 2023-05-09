namespace IntegratedProtection.Infrastructure.Configurations;

#region Central Security Configurations 
public class CriminalConfigurations : IEntityTypeConfiguration<Criminal>
{
    public void Configure(EntityTypeBuilder<Criminal> builder)
    {
    }
}

#endregion

#region Civil Registry Configurations
public class CardConfigurations : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {

    }
}

public class PersonConfigurations : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {

    }
}

#endregion

#region Traffic Configurations
public class CarConfigurations : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
    }
}
public class CarDriverConfigurations : IEntityTypeConfiguration<CarDriver>
{
    public void Configure(EntityTypeBuilder<CarDriver> builder)
    {
    }
}
public class DriverConfigurations : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
    }
}

public class StolenCarConfigurations : IEntityTypeConfiguration<StolenCar>
{
    public void Configure(EntityTypeBuilder<StolenCar> builder)
    {
    }
}

public class TrafficOfficerConfigurations : IEntityTypeConfiguration<TrafficOfficer>
{
    public void Configure(EntityTypeBuilder<TrafficOfficer> builder)
    {
    }
}
#endregion