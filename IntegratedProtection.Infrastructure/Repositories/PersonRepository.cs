namespace IntegratedProtection.Infrastructure.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }

    public async Task<Person> GetRelatedDataAsync(int id)
    {
        var person = await _entities
                                .AsNoTracking()
                                .FirstOrDefaultAsync(p => p.Id.Equals(id));
        if (person.Age < 16)
            return null;

        var personCard = await _entities
            .Where(e => e.Id.Equals(person.Id))
            .Include(e => e.Card)
            .FirstOrDefaultAsync();

        return personCard;
    }
}
