namespace IntegratedProtection.Infrastructure.IRepositories;

public interface IPersonRepository : IRepository<Person>
{
    Task<Person> GetRelatedDataAsync(int id);
}
