using ef_core_console_app.Models;

namespace ef_core_console_app.Repositories;

public interface IRepository<TEntity,TKey> where TEntity : Base<TKey>
{
    public Task<bool> CreateEntity(TEntity Entity);
    public Task<bool> UpdateEntity(TEntity Entity, TKey Key);
    public Task<bool> DeleteEntity(TKey Key);
}