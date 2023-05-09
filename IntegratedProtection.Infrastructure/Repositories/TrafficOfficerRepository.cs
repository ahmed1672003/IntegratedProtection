namespace IntegratedProtection.Infrastructure.Repositories;

public class TrafficOfficerRepository : Repository<TrafficOfficer>, ITrafficOfficerRepository
{
    public TrafficOfficerRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }
}
