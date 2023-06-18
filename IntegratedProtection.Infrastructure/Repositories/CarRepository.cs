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

    //public async Task<KeyValuePair<Car, bool>> GetStolenCarStateAsync(Expression<Func<Car, bool>> filter)
    //{
    //    Dictionary<Car, bool> carState = new();

    //    var car = await _context.Cars
    //            .Where(filter)
    //            .Include(c => c.StolenCars)
    //            .ThenInclude(c => c.TrafficOfficer)
    //            .FirstOrDefaultAsync();

    //    if (car.StolenCars.Any())
    //        carState.Add(car, true);
    //    else
    //        carState.Add(car, false);

    //    return carState.FirstOrDefault();
    //}

    public async Task<(Car car, bool state)> GetStolenCarStateAsync(Expression<Func<Car, bool>> filter)
    {
        var car = await _context.Cars
                .Where(filter)
                .Include(c => c.StolenCars)
                .ThenInclude(c => c.TrafficOfficer)
                .FirstOrDefaultAsync();

        if (car.StolenCars.Any())
            return (car, true);
        else
            return (car, false);
    }
}
