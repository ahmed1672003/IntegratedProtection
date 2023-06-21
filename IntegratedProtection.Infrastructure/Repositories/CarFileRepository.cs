using IntegratedProtection.Core.FilesEntity;

namespace IntegratedProtection.Infrastructure.Repositories;
public class CarFileRepository : Repository<CarFile>, ICarFileRepository
{
    public CarFileRepository(IntegratedProtectionDbContext context) : base(context) { }
}
