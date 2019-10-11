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
    public class ParticipantRepository : BaseRepository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(AppDbContext appDbContext) : base(appDbContext)
        { }

        //public async Task<IEnumerable<Participant>> ListAsync()
        //{
        //    // return await base.DbContext.Categories.ToListAsync();
        //    return await base.ListAsync();
        //}

        //public async Task AddAsync(Category category)
        //{
        //    await base.AddAsync(category);
        //}

        //public async Task<Category> FindByIdAsync(int id)
        //{
        //    return await base.DbContext.Categories.FindAsync(id);
        //}

        //public void Update(Category category)
        //{
        //    base.DbContext.Categories.Update(category);
        //}

        //public void Remove(Category category)
        //{
        //    base.DbContext.Categories.Remove(category);
        //}
    }
}
