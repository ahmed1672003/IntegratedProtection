namespace IntegratedProtection.Infrastructure.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Person>> GetAllAsyncOptimizedQuery()
    {
        var result = CompileQuery(_context);
        return await Task.FromResult(result);
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

    private static readonly Func<IntegratedProtectionDbContext, IEnumerable<Person>> CompileQuery =
         EF.CompileQuery((IntegratedProtectionDbContext context) =>
                context.Persons.AsNoTracking()
                    .OrderByDescending(e => e.Age)
                        .AsQueryable()
                            .ToList()
                            );
}
