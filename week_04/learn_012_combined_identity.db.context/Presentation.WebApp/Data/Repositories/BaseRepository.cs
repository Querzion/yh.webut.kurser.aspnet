using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Presentation.WebApp.Data.Repositories;

public abstract class BaseRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }


    #region CRUD Methods

        #region Add Methods

            public virtual async Task<bool> AddAsync(TEntity entity)
            {
                try
                {
                    await _dbSet.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }

        #endregion

        #region Get Methods

            public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            {
                var entities = await _dbSet.ToListAsync();
                return entities;
            }
        
            public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
            {
                var entities = await _dbSet.Where(predicate).ToListAsync();
                return entities;
            }
        
            public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
            {
                var entity = await _dbSet.FirstOrDefaultAsync(predicate);
                return entity;
            }
        
        #endregion

        #region Update Methods
        
            public virtual async Task<bool> UpdateAsync(TEntity entity)
            {
                try
                {
                    _dbSet.Update(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }
        
        #endregion

        #region Delete Methods
        
            public virtual async Task<bool> DeleteAsync(TEntity entity)
            {
                try
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }
        
        #endregion

        #region Exist Methods

            public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
            {
                var exists = await _dbSet.AnyAsync(predicate);
                return exists;
            }

        #endregion

    #endregion
}