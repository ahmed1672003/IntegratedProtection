using IntegratedProtection.Core.FilesEntity;

namespace IntegratedProtection.Infrastructure.Repositories;
public class UploadedFileRepository : Repository<UploadedFile>, IUploadedFileRepository
{
    public UploadedFileRepository(IntegratedProtectionDbContext context) : base(context)
    {
    }
}
