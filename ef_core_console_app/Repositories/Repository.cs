using ef_core_console_app.Data;
using ef_core_console_app.Models;
using System.Diagnostics.CodeAnalysis;

namespace ef_core_console_app.Repositories;

public class Repository<TEntity, TKey>([NotNull] AppDbContext _dbContext) : IRepository<TEntity, TKey> where TEntity : Base<TKey>
{
    private readonly AppDbContext dbContext = _dbContext;
    public async Task<bool> CreateEntity(TEntity Entity)
    {
        try
        {
            dbContext.Set<TEntity>().Add(Entity);
            var p = await dbContext.SaveChangesAsync();
            return p > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeleteEntity(TKey Key)
    {
        try
        {
            TEntity entity = await dbContext.Set<TEntity>().FindAsync(Key) ?? throw new KeyNotFoundException();
            dbContext.Set<TEntity>().Remove(entity);
            var p = await dbContext.SaveChangesAsync();
            return p > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> UpdateEntity(TEntity Entity, TKey Key)
    {
        TEntity existing = await dbContext.Set<TEntity>().FindAsync(Key) ?? throw new KeyNotFoundException();
        try
        {
            dbContext.Entry(existing).CurrentValues.SetValues(Entity);
            var p = await dbContext.SaveChangesAsync();
            return p > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}