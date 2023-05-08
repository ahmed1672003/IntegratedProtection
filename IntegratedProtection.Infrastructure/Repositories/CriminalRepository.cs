namespace IntegratedProtection.Infrastructure.Repositories;

public class CriminalRepository : Repository<Criminal>, ICriminalRepository
{
    public CriminalRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }
}
