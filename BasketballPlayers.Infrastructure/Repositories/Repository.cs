using BasketballPlayers.Domain.Common;
using BasketballPlayers.Infrastructure.Data;
using BasketballPlayers.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Infrastructure.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
             await this._dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null) 
            {
                _dbSet.Remove(entity);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this._dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await this._dbSet.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
             this._dbSet.Update(entity);
        }
    }
}
