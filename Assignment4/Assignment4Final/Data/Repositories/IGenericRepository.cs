namespace Assignment4Final.Data.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetAsync(int id);
    Task<TEntity?> AddAsync(TEntity entity);
    Task<TEntity?> UpdateAsync(int id, TEntity entity);
    Task<TEntity?> DeleteAsync(int id);
    bool EntityExists(int id);
}
