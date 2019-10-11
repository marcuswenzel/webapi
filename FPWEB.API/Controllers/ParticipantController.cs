using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FPWEB.API.Domain.Models;
using FPWEB.API.Domain.Services;
using FPWEB.API.Extensions;
using FPWEB.API.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPWEB.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Participant")]

    //mvteste [Route("api/[controller]")]
    public class ParticipantController : Controller
    {
        private readonly IParticipantService _participantService;
        private readonly IMapper _mapper;

        public ParticipantController(IParticipantService participantService, IMapper mapper)
        {
            _participantService = participantService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ParticipantResource>> GetAllAssync()
        {
            var participants = await _participantService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Participant>, IEnumerable<ParticipantResource>>(participants);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveParticipantResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var participant = _mapper.Map<SaveParticipantResource, Participant>(resource);
            var result = await _participantService.SaveAsync(participant);

            if (!result.Success)
                return BadRequest(result.Message);

            var participantResource = _mapper.Map<Participant, ParticipantResource>(result.Participant);

            return Ok(participantResource);
        }


        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        //{
        //    if (!ModelState.IsValid)
        //        BadRequest(ModelState.GetErrorMessages());

        //    var category = _mapper.Map<SaveCategoryResource, Category>(resource);
        //    var result = await _categoryService.UpdateAsync(id, category);

        //    if (!result.Success)
        //        BadRequest(result.Message);

        //    var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);

        //    return Ok(categoryResource);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var result = await _categoryService.DeleteAsync(id);

        //    if (!result.Success)
        //        BadRequest(result.Message);

        //    var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);

        //    return Ok(categoryResource);
        //}
    }
}