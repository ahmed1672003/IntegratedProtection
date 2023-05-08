namespace IntegratedProtection.Infrastructure.Repositories;

public class CarDriverRepository : Repository<CarDriver>, ICarDriverRepository
{
    public CarDriverRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }
}
