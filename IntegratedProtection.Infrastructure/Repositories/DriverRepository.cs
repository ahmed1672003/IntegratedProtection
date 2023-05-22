namespace IntegratedProtection.Infrastructure.Repositories;

public class DriverRepository : Repository<Driver>, IDriverRepository
{
    public DriverRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }

    public async Task<Driver> GetRelatedDataAsync(int id)
    {
        var driver = await _entities
                        .AsNoTracking()
                        .Where(e => e.Id.Equals(id))
                        .Include(e => e.CarsDrivers)
                        .ThenInclude(e => e.Car)
                        .FirstOrDefaultAsync();
        return driver;
    }
}
