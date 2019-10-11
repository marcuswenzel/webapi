using FPWEB.API.Domain.Communication;
using FPWEB.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPWEB.API.Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();

        Task<CustomerResponse> SaveAsync(Customer customer);

        //Task<CustomerResponse> UpdateAsync(int id, Customer customer);

        //Task<CustomerResponse> DeleteAsync(int id);

    }
}
