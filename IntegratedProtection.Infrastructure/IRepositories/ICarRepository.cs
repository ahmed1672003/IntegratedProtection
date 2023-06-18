namespace IntegratedProtection.Infrastructure.IRepositories;

public interface ICarRepository : IRepository<Car>
{
    Task<Car> GetRelatedDataAsync(int id);
    Task<(Car car, bool state)> GetStolenCarStateAsync(Expression<Func<Car, bool>> filter);
}
