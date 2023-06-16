namespace IntegratedProtection.Infrastructure.IRepositories;
public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task<TEntity> UpdateAsync(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    Task<TEntity> DeleteAsync(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);
    Task<TEntity>
        GetAsync(Expression<Func<TEntity, bool>> filter, string[] includes = null);
    Task<IQueryable<TEntity>>
        GetAllAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Expression<Func<TEntity, object>> oredrBy = null,
        OrderByDirection orderByDirection = OrderByDirection.ASC,
        string[] includes = null,
        int? take = null,
        int? skip = null);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
    Task<bool> IsExist(Expression<Func<TEntity, bool>> filter = null);
    Task ExecuteUpdateAsync(
          Func<TEntity, object> property,
        Func<TEntity, object> propertyExpression,
        Expression<Func<TEntity, bool>> filter = null);
    Task ExecuteDeleteAsync(Expression<Func<TEntity, bool>> filter = null);
    Task<IQueryable<ReferenceEntry>> GetReferences(TEntity entity);
    Task<ReferenceEntry<TEntity, object>> GetReference(TEntity entity, Expression<Func<TEntity, object>> property);
}
