using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STORE.DTOs;
using STORE.MIDDLEWARE.StoreResponseHelper;
using STORE.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductModelController : ControllerBase
    {
        private readonly IProductModelService _productModelService;
        public ProductModelController(IProductModelService productModelService)
        {
            _productModelService = productModelService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductModels()
        {
            var models = await _productModelService.GetAllProductModelAsync().ConfigureAwait(false);
            HttpContext.Items["message"] = "Modeller başarılı bir şekilde getirildi.";
            return Ok(models);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductModel(int id)
        {
            var model = await _productModelService.GetByIdProductModelAsync(id).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen model başarılı bir şekilde getirildi.";
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddProductModel(ProductModelDTO productModelDTO)
        {
            var model = await _productModelService.AddProductModelAsync(productModelDTO).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen model başarılı bir şekilde eklendi.";
            return Ok(model);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductModel(int id)
        {
            await _productModelService.DeleteProductModelAsync(id).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen model başarılı şekilde silindi.";
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductModel(ProductModelDTO productModelDTO)
        {
            var model = await _productModelService.UpdateProductModelAsync(productModelDTO).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen model başarılı şekilde güncellendi.";
            return Ok(model);
        }
    }
}
