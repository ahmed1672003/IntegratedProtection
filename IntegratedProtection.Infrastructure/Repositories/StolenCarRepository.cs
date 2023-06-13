namespace IntegratedProtection.Infrastructure.Repositories;

public class StolenCarRepository : Repository<StolenCar>, IStolenCarRepository
{
    public StolenCarRepository(IntegratedProtectionDbContext context) : base(context) { }

    public async Task<StolenCar> GetStolenCarWithTrafficOfficerAsync(string number, string letters)
    {
        var car = await _context.Cars
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(
            c => c.Number.Equals(number) && c.Letters.Equals(letters));

        if (car == null)
            return null;

        var stolenCar = await _entities
                                .AsNoTracking()
                                .Where(sc => sc.CarId.Equals(car.Id))
                                .Include(sc => sc.TrafficOfficer)
                                .FirstOrDefaultAsync();
        return stolenCar;
    }
}
