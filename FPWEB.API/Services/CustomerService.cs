using FPWEB.API.Domain.Communication;
using FPWEB.API.Domain.Models;
using FPWEB.API.Domain.Repositories;
using FPWEB.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPWEB.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _customerRepository.ListAsync();
        }

        public async Task<CustomerResponse> SaveAsync(Customer Customer)
        {

            //var existingCategory = await _categoryRepository.FindByIdAsync(id);
            //if (existingCategory == null)
            //    return new CategoryResponse("Category not found.");


            try
            {
                await _customerRepository.AddAsync(Customer);
                await _unitOfWork.CompleteAsync();

                return new CustomerResponse(Customer);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CustomerResponse($"An error occurred when saving the Customer: {ex.Message}");
            }
        }

        //    public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        //    {

        //        var existingCategory = await _categoryRepository.FindByIdAsync(id);
        //        if (existingCategory == null)
        //            return new CategoryResponse("Category not found.");

        //        existingCategory.Name = category.Name;

        //        try
        //        {
        //            _categoryRepository.Update(existingCategory);
        //            await _unitOfWork.CompleteAsync();

        //            return new CategoryResponse(existingCategory);
        //        }
        //        catch (Exception ex)
        //        {
        //            // Do some logging stuff
        //            return new CategoryResponse($"An error occurred when updating the category: {ex.Message}");
        //        }
        //    }

        //    public async Task<CategoryResponse> DeleteAsync(int id)
        //    {
        //        var category = await _categoryRepository.FindByIdAsync(id);
        //        if (category == null)
        //            return new CategoryResponse("Category not found.");

        //        try
        //        {
        //            _categoryRepository.Remove(category);
        //            await _unitOfWork.CompleteAsync();

        //            return new CategoryResponse(category);
        //        }
        //        catch (Exception ex)
        //        {
        //            // Do some logging stuff
        //            return new CategoryResponse($"An error occurred when removing the category: {ex.Message}");
        //        }
        //    }


    }
}
