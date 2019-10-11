using FPWEB.API.Domain.Communication;
using FPWEB.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPWEB.API.Domain.Services
{
    public interface IParticipantService
    {
        Task<IEnumerable<Participant>> ListAsync();

        Task<ParticipantResponse> SaveAsync(Participant participant);

        //Task<CustomerResponse> UpdateAsync(int id, Customer customer);

        //Task<CustomerResponse> DeleteAsync(int id);

    }
}
