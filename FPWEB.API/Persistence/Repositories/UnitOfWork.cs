using FPWEB.API.Domain.Repositories;
using FPWEB.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPWEB.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _AppDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public async Task CompleteAsync()
        {
            await _AppDbContext.SaveChangesAsync();
        }
    }
}
