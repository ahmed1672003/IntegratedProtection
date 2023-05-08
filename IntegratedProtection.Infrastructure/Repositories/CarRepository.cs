namespace IntegratedProtection.Infrastructure.Repositories;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }
}
