namespace IntegratedProtection.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly IntegratedProtectionDbContext _context;

    protected readonly DbSet<TEntity> _entities;

    public Repository(IntegratedProtectionDbContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    #region Queries
    public async Task<IQueryable<TEntity>>
        GetAllAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Expression<Func<TEntity, object>> oredrBy = null,
        OrderByDirection orderByDirection = OrderByDirection.ASC,
        string[] includes = null,
        int? take = null,
        int? skip = null)
    {
        IQueryable<TEntity> entities = _entities.AsNoTracking();

        if (filter is not null)
            entities = entities.Where(filter);

        if (skip.HasValue)
            entities = entities.Skip(skip.Value);

        if (take.HasValue)
            entities = entities.Take(take.Value);

        if (includes is not null)
            foreach (var include in includes)
                entities = entities.Include(include);

        if (oredrBy is not null)
        {
            if (orderByDirection == OrderByDirection.ASC)
                entities = entities.OrderBy(oredrBy);
            else
                entities = entities.OrderByDescending(oredrBy);
        }

        return await Task.FromResult(entities);
    }

    public virtual async Task<TEntity>
        GetAsync(
        Expression<Func<TEntity, bool>> filter,
        string[] includes = null)
    {
        IQueryable<TEntity> entities = _entities.AsNoTracking().Where(filter);

        if (includes is not null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return await entities.FirstOrDefaultAsync(filter);
    }


    public async Task<int>
        CountAsync(
        Expression<Func<TEntity, bool>> filter = null)
    {
        if (filter is null)
            return await _entities.CountAsync();
        else
            return await _entities.CountAsync(filter);
    }
    public async Task<bool> IsExist(Expression<Func<TEntity, bool>> filter = null)
    {
        if (filter is null)
            return await _entities.AnyAsync();
        else
            return await _entities.AnyAsync(filter);
    }
    #endregion

    #region Commands
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
        return entity;
    }
    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities) =>
        await _entities.AddRangeAsync(entities);
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await Task.FromResult(_entities.Update(entity));
        return entity;
    }
    public virtual void UpdateRange(IEnumerable<TEntity> entities) =>
        _entities.UpdateRange(entities);
    public virtual async Task<TEntity> DeleteAsync(TEntity entity)
    {
        await Task.FromResult(_entities.Remove(entity));
        return entity;
    }
    public virtual void DeleteRange(IEnumerable<TEntity> entities) =>
        _entities.RemoveRange(entities);

    public virtual async Task
        ExecuteUpdateAsync(
        Func<TEntity, object> property,
        Func<TEntity, object> propertyExpression,
        Expression<Func<TEntity, bool>> filter = null)
    {
        if (filter is null)
            await _entities.ExecuteUpdateAsync(entity =>
            entity.SetProperty(property, propertyExpression));
        else
            await _entities.Where(filter).ExecuteUpdateAsync(entity =>
            entity.SetProperty(property, propertyExpression));
    }

    public virtual async Task
        ExecuteDeleteAsync(
        Expression<Func<TEntity, bool>> filter = null)
    {
        if (filter is null)
            await _entities.ExecuteDeleteAsync();
        else
            await _entities.Where(filter).ExecuteDeleteAsync();
    }
    #endregion
}
