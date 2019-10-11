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
    [Route("api/Products")]

    //mvteste [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllAssync()
        {
            var products = await _productService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Product, ProductResource>(result.Product);

            return Ok(categoryResource);
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