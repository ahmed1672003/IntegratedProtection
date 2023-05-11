namespace IntegratedProtection.Application.IHelpers;

public interface IFileHelper<TEntity> where TEntity : class
{
    Task<string> ToStore(IFormFile file);
}
