using FPWEB.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPWEB.API.Domain.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> ListAsync();

        Task AddAsync(TEntity entity);

        Task<TEntity> FindByIdAsync(int id);

        Task UpdateAsync(TEntity entity);

        Task RemoveAsync(TEntity entity);


        //void Update(TEntity entity);

        //void Remove(TEntity entity);
    }
}
