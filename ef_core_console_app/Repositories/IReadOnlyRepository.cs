using ef_core_console_app.Models;

namespace ef_core_console_app.Repositories;

public interface IReadOnlyRepository<TEntity,TKey> where TEntity:Base<TKey>
{
    public Task<IEnumerable<TEntity>> GetAll();
    public Task<TEntity> GetById(int id);
    public Task<PaginatedResult<TEntity>> PaginatedResult(int page, int pageSize);
}

public record PaginatedResult<TResult>
{
    public IEnumerable<TResult> Data { get; set; } = default!;
    public int Total { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}