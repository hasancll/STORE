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
    public class ProductColorController : ControllerBase
    {
        private readonly IProductColorService _productColorService;

        public ProductColorController(IProductColorService productColorService)
        {
            _productColorService = productColorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductColors()
        {
            var colors = await _productColorService.GetAllProductColorAsync().ConfigureAwait(false);
            HttpContext.Items["message"] = "Renkler başarılı şekilde getirildi";
            return Ok(colors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductColors(int id)
        {
            var color = await _productColorService.GetByIdProductColorAsync(id).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen renk başarılı bir şekilde getirildi.";
            return Ok(color);
        }
        [HttpPost]
        public async Task<IActionResult> AddToProductColor(ProductColorDTO productColorDTO)
        {
            var color = await _productColorService.AddProductColorAsync(productColorDTO).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen renk başarılı bir şekilde eklendi.";
            return Ok(color);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToProductColor(int id)
        {
            await _productColorService.DeleteProductColorAsync(id).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen renk silindi";
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateToProductColor(ProductColorDTO productColorDTO)
        {
            var color = await _productColorService.UpdateProductColorAsync(productColorDTO).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen renk güncellendi.";
            return Ok(color);
        }
    }
}
