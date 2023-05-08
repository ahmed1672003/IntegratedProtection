
namespace IntegratedProtection.Infrastructure.Repositories;

public class CardRepository : Repository<Card>, ICardRepository
{
    public CardRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }
}
