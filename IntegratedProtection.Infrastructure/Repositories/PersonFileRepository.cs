using IntegratedProtection.Core.FilesEntity;

namespace IntegratedProtection.Infrastructure.Repositories;
public class PersonFileRepository : Repository<PersonFile>, IPersonFileRepository
{
    public PersonFileRepository(IntegratedProtectionDbContext context) : base(context) { }
}
