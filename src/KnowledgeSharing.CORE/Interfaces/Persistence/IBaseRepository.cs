namespace KnowledgeSharing.CORE.Interfaces.Persistence;

public interface IBaseRepository<TEntity, TId>
    where TEntity : class
{
    Task<TId> CreateAsync(TEntity entity, CancellationToken ct);
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken ct);
    Task<bool> UpdateAsync(TEntity entity, CancellationToken ct);
    Task<bool> DeleteAsync(TId id, CancellationToken ct);
}