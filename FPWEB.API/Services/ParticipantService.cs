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
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ParticipantService(IParticipantRepository participantRepository, IUnitOfWork unitOfWork)
        {
            _participantRepository = participantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Participant>> ListAsync()
        {
            return await _participantRepository.ListAsync();
        }

        public async Task<ParticipantResponse> SaveAsync(Participant Participant)
        {

            //var existingCategory = await _categoryRepository.FindByIdAsync(id);
            //if (existingCategory == null)
            //    return new CategoryResponse("Category not found.");


            try
            {
                await _participantRepository.AddAsync(Participant);
                await _unitOfWork.CompleteAsync();

                return new ParticipantResponse(Participant);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ParticipantResponse($"An error occurred when saving the Participant: {ex.Message}");
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
