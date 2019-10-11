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
    [Route("api/Customer")]

    //mvteste [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerResource>> GetAllAssync()
        {
            var customers = await _customerService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCustomerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);
            var result = await _customerService.SaveAsync(customer);

            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Customer);

            return Ok(customerResource);
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