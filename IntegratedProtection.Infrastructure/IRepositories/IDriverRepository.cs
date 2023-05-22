namespace IntegratedProtection.Infrastructure.IRepositories;

public interface IDriverRepository : IRepository<Driver>
{
    Task<Driver> GetRelatedDataAsync(int id);
}
