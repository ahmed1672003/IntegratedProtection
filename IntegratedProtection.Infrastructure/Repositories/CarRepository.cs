namespace IntegratedProtection.Infrastructure.Repositories;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }

    public async Task<Car> GetRelatedDataAsync(int id)
    {
        var carWithDrivers = await _entities
            .AsNoTracking()
            .Where(e => e.Id.Equals(id))
            .Include(e => e.CarDriver)
            .ThenInclude(e => e.Driver)
            .Include(e => e.StolenCars)
            .ThenInclude(e => e.TrafficOfficer)
            .FirstOrDefaultAsync();
        return carWithDrivers;
    }
}
