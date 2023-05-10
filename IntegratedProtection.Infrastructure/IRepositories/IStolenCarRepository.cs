using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IntegratedProtection.Infrastructure.IRepositories;

public interface IStolenCarRepository : IRepository<StolenCar>
{
}
