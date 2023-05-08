namespace IntegratedProtection.Infrastructure.IRepositories;

public interface IUnitOfWork : IAsyncDisposable
{
    ICardRepository Cards { get; }
    ICarDriverRepository CarsDrivers { get; }
    ICarRepository Cars { get; }
    ICriminalRepository Criminals { get; }
    IDriverRepository Drivers { get; }
    IPersonRepository Persons { get; }

    Task<int> SaveChangesAsync();
}
