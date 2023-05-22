namespace IntegratedProtection.Infrastructure.IRepositories;

public interface ICarRepository : IRepository<Car>
{
    Task<Car> GetRelatedDataAsync(int id);
}
