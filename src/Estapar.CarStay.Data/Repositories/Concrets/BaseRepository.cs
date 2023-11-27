using Estapar.CarStay.Data.Context;
using Estapar.CarStay.Data.Entity;
using Estapar.CarStay.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Estapar.CarStay.Data.Repositories.Concrets
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        protected CarStayContext _context;
        protected DbSet<TEntity> dbSet;

        #region Ctor
        public BaseRepository(CarStayContext dbContext)
        {
            _context = dbContext;
            dbSet = _context.Set<TEntity>();
        }
        #endregion       

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(string code)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Code == code);
        }

        public async Task CreateAsync(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entity)
        {
            await dbSet.AddRangeAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var entity = await GetByIdAsync(code);
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
