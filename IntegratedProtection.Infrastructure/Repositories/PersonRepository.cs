namespace IntegratedProtection.Infrastructure.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }
}
