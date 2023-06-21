using IntegratedProtection.Core.FilesEntity;
using IntegratedProtection.Infrastructure.Configurations.FilesConfigurations;

namespace IntegratedProtection.Infrastructure.Context;
public class IntegratedProtectionDbContext : DbContext
{
    public IntegratedProtectionDbContext(DbContextOptions<IntegratedProtectionDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        new CriminalConfigurations().Configure(builder.Entity<Criminal>());
        new CardConfigurations().Configure(builder.Entity<Card>());
        new PersonConfigurations().Configure(builder.Entity<Person>());
        new CarConfigurations().Configure(builder.Entity<Car>());
        new CarDriverConfigurations().Configure(builder.Entity<CarDriver>());
        new DriverConfigurations().Configure(builder.Entity<Driver>());
        new StolenCarConfigurations().Configure(builder.Entity<StolenCar>());
        new TrafficOfficerConfigurations().Configure(builder.Entity<TrafficOfficer>());
        new CarFileConfigurations().Configure(builder.Entity<CarFile>());
        new PersonFileConfigurations().Configure(builder.Entity<PersonFile>());
    }

    #region Central Security Database Mapping
    public DbSet<Criminal> Criminals { get; set; }
    #endregion

    #region Civil Registry Database Mapping
    public DbSet<Card> Cards { get; set; }
    public DbSet<Person> Persons { get; set; }
    #endregion

    #region Traffic Database Mapping
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarDriver> CarsDrivers { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<StolenCar> StolenCars { get; set; }
    public DbSet<TrafficOfficer> TrafficOfficers { get; set; }
    #endregion
    public DbSet<PersonFile> PersonFiles { get; set; }
    public DbSet<CarFile> CarFiles { get; set; }
}
