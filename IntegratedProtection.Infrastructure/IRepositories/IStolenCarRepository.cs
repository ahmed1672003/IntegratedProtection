namespace IntegratedProtection.Infrastructure.IRepositories;

public interface IStolenCarRepository : IRepository<StolenCar>
{
    Task<StolenCar> GetStolenCarWithTrafficOfficerAsync(string number, string letters);
}
