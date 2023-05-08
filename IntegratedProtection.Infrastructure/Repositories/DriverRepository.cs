namespace IntegratedProtection.Infrastructure.Repositories;

public class DriverRepository : Repository<Driver>, IDriverRepository
{
    public DriverRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }
}
