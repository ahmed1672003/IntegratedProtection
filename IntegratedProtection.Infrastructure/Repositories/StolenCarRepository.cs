namespace IntegratedProtection.Infrastructure.Repositories;

public class StolenCarRepository : Repository<StolenCar>, IStolenCarRepository
{
    public StolenCarRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }
}
