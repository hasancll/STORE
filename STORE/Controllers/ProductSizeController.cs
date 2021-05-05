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
    public class ProductSizeController : ControllerBase
    {
        private readonly IProductSizeService _productSizeService;

        public ProductSizeController(IProductSizeService productSizeService)
        {
            _productSizeService = productSizeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductSize()
        {
            var sizes = await _productSizeService.GetAllProductSizesAsync().ConfigureAwait(false);
            HttpContext.Items["message"] = "Bedenler başarılı bir şekilde getirildi.";
            return Ok(sizes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductSize(int id)
        {
            var size = await _productSizeService.GetByIdProductSizeAsync(id).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen gider başarılı bir şekilde getirildi.";
            return Ok(size);

        }
        [HttpPost]
        public async Task<IActionResult> AddProductSize(ProductSizeDTO productSizeDTO)
        {
            var size = await _productSizeService.AddProductSizeAsync(productSizeDTO).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen beden başarılı bir şekilde eklendi.";
            return Ok(size);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductSize(int id)
        {
            await _productSizeService.DeleteProductSizeAsync(id).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen ürün başarılı bir şekilde silindi.";
            return Ok();
        }
    }
}
