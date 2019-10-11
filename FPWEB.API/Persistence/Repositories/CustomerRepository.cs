using FPWEB.API.Domain.Models;
using FPWEB.API.Domain.Repositories;
using FPWEB.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPWEB.API.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext appDbContext) : base(appDbContext)
        { }


    //    public async Task<IEnumerable<Customer>> ListAsync()
    //    {
    //        //return await _appDbContext.Products.ToListAsync();

    //        return await _appDbContext.Products.Include(p => p.Category).ToListAsync();
    //    }


    //    public Task AddAsync(Product product)
    //    {
    //        return _appDbContext.Products.AddAsync(product);
    //    }

    //    //public async Task<Category> FindByIdAsync(int id)
    //    //{
    //    //    return await _appDbContext.Categories.FindAsync(id);
    //    //}

    //    //public void Update(Category category)
    //    //{
    //    //    _appDbContext.Categories.Update(category);
    //    //}

    //    //public void Remove(Category category)
    //    //{
    //    //    _appDbContext.Categories.Remove(category);
    //    //}
    }
}
