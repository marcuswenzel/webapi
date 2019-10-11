using FPWEB.API.Domain.Repositories;
using FPWEB.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FPWEB.API.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
//        where TContext : AppDbContext
    {
        protected readonly AppDbContext DbContext;
        protected DbSet<TEntity> DbSet;

        protected BaseRepository(AppDbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await DbSet.ToListAsync();

        }

        public virtual async Task<Tuple<IEnumerable<TEntity>, int>> GetAll
(
    int skip,
    int take,
    bool asNoTracking = true
)
        {
            var databaseCount = await DbSet.CountAsync().ConfigureAwait(false);
            if (asNoTracking)
                return new Tuple<IEnumerable<TEntity>, int>
                (
                    await DbSet.AsNoTracking().Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                    databaseCount
                );

            return new Tuple<IEnumerable<TEntity>, int>
            (
                await DbSet.Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                databaseCount
            );
        }


        public virtual async Task<Tuple<IEnumerable<TEntity>, int>> GetAll
(
    int skip,
    int take,
    Expression<Func<TEntity, bool>> where,
    bool asNoTracking = true
)
        {
            var databaseCount = await DbSet.CountAsync().ConfigureAwait(false);
            if (asNoTracking)
                return new Tuple<IEnumerable<TEntity>, int>
                (
                    await DbSet.AsNoTracking().Where(where).Skip(skip).Take(take).ToListAsync()
                    .ConfigureAwait(false),
                    databaseCount
                );

            return new Tuple<IEnumerable<TEntity>, int>
            (
                await DbSet.Where(where).Skip(skip).Take(take).ToListAsync()
                .ConfigureAwait(false),
                databaseCount
            );
        }



        public virtual async Task<Tuple<IEnumerable<TEntity>, int>> GetAll
(
    int skip,
    int take,
    Expression<Func<TEntity, bool>> where,
    Expression<Func<TEntity, object>> orderBy,
    bool asNoTracking = true
)
        {
            var databaseCount = await DbSet.CountAsync().ConfigureAwait(false);
            if (asNoTracking)
                return new Tuple<IEnumerable<TEntity>, int>
                (
                    await DbSet.AsNoTracking().OrderBy(orderBy).Where(where).Skip(skip).Take(take).ToListAsync()
                    .ConfigureAwait(false),
                    databaseCount
                );

            return new Tuple<IEnumerable<TEntity>, int>
            (
                await DbSet.OrderBy(orderBy).Where(where).Skip(skip).Take(take).ToListAsync()
                .ConfigureAwait(false),
                databaseCount
            );
        }




        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity).ConfigureAwait(false);
        }


        public virtual Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }



        public virtual Task RemoveAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<TEntity> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
