using ef_core_console_app.Data;
using ef_core_console_app.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ef_core_console_app.Repositories;

public class ReadOnlyRepository<TEntity, TKey>([NotNull] AppDbContext _dbContext) : IReadOnlyRepository<TEntity, TKey> where TEntity : Base<TKey>
{
    private readonly AppDbContext dbContext = _dbContext;
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await dbContext.Set<TEntity>().FindAsync(id) ?? throw new KeyNotFoundException();
    }

    public async Task<PaginatedResult<TEntity>> PaginatedResult(int page, int pageSize)
    {
        var data = await dbContext.Set<TEntity>().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedResult<TEntity>
        {
            Data = data,
            Page = page,
            PageSize = pageSize,
            Total = data.Count
        };
    }
}