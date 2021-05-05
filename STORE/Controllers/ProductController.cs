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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToProduct(ProductDTO productDTO)
        {
            var product = await _productService.AddProductAsync(productDTO).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen ürün başarılı bir şekilde eklendi.";
            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductAsync().ConfigureAwait(false);
            HttpContext.Items["message"] = "Ürünler başarılı bir şekilde getirildi.";
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProducts(int id)
        {
            var product = await _productService.GetByIdProductAsync(id).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen ürün başarılı bir şekilde getirildi.";
            return Ok(product);
        }
        [HttpGet("Barcode/{barcode}")]
        public async Task<IActionResult> GetByInnerProduct(string barcode)
        {
            var product = await _productService.GetByBarcodeProduct(barcode).ConfigureAwait(false);
            HttpContext.Items["message"] = "Barkoda ait ürün başarılı bir şekilde getirildi.";
            return Ok(product);
         ;
        }
        [HttpPut]
        public async Task<IActionResult> UpdateToProduct(ProductDTO productDTO)
        {
            var product = await _productService.UpdateProductAsync(productDTO).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen ürün başarılı bir şekilde güncellendi.";
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToProduct(int id)
        {
            await _productService.DeleteProductAsync(id).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen ürün başarılı bir şekilde silindi.";
            return Ok();
        }
    }
}
