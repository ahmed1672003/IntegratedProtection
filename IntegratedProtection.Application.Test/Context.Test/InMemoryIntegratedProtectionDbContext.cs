using IntegratedProtection.Infrastructure.Context;

using Microsoft.EntityFrameworkCore;

namespace IntegratedProtection.Application.Test.Context.Test;
internal class InMemoryIntegratedProtectionDbContext : IntegratedProtectionDbContext
{
    public InMemoryIntegratedProtectionDbContext(DbContextOptions<IntegratedProtectionDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase($"IntegratedProtection{Guid.NewGuid().ToString()}");
    }
    public override void Dispose()
    {
        Database.EnsureDeleted();
        base.Dispose();
    }
}
