using IntegratedProtection.Infrastructure.Repositories;

namespace IntegratedProtection.Application.Test.Mocks;
internal class MockUnitOfWork
{
    public static Mock<IUnitOfWork> GetUnitOfWork(CriminalRepository repo)
    {
        MockRepository mockRepository = new(MockBehavior.Strict);
        var context = mockRepository.Create<IUnitOfWork>(MockBehavior.Loose, repo);
        context.SetupGet(e => e.Criminals);
        context.Verify(e => e.Criminals);
        return context;
    }
}
