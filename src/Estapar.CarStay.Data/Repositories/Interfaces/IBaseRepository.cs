using Estapar.CarStay.Data.Entity;

namespace Estapar.CarStay.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(string code);
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(string code);
    }
}
