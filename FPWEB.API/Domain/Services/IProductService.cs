using FPWEB.API.Domain.Communication;
using FPWEB.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPWEB.API.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();

        Task<ProductResponse> SaveAsync(Product product);

        //Task<CategoryResponse> UpdateAsync(int id, Category category);

        //Task<CategoryResponse> DeleteAsync(int id);

    }
}
