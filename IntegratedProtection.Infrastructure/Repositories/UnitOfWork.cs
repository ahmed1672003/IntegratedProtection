namespace IntegratedProtection.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly IntegratedProtectionDbContext _context;
    public ICardRepository Cards { get; private set; }
    public ICarDriverRepository CarsDrivers { get; private set; }
    public ICarRepository Cars { get; private set; }
    public ICriminalRepository Criminals { get; private set; }
    public IDriverRepository Drivers { get; private set; }
    public IPersonRepository Persons { get; private set; }
    public IStolenCarRepository StolenCars { get; private set; }
    public ITrafficOfficerRepository TrafficOfficers { get; private set; }
    public ICarFileRepository CarFiles { get; private set; }
    public IPersonFileRepository PersonFiles { get; private set; }

    public UnitOfWork(IntegratedProtectionDbContext context)
    {
        _context = context;
        Cards = new CardRepository(_context);
        CarsDrivers = new CarDriverRepository(_context);
        Cars = new CarRepository(_context);
        Criminals = new CriminalRepository(_context);
        Drivers = new DriverRepository(_context);
        Persons = new PersonRepository(_context);
        StolenCars = new StolenCarRepository(_context);
        TrafficOfficers = new TrafficOfficerRepository(_context);
        CarFiles = new CarFileRepository(_context);
        PersonFiles = new PersonFileRepository(_context);


    }
    public async ValueTask DisposeAsync() => await _context.DisposeAsync();

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
