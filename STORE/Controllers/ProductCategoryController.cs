using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productcategoryService;
        public ProductCategoryController(IProductCategoryService productcategoryService)
        {
            _productcategoryService = productcategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _productcategoryService.GetAllProductCategoryAsync().ConfigureAwait(false);

            return Ok(StoreResponse.GetStoreResponseModel(true, "200", "Kategoriler başarıyla getirildi.", categories));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _productcategoryService.GetByIdProductCategoryAsync(id).ConfigureAwait(false);

            return Ok(StoreResponse.GetStoreResponseModel(true,"200","Kategpri başarıyla getirildi",category));
        }
        [HttpPost]
        public async Task<IActionResult> AddProductCategory(ProductCategoryDTO productCategoryDTO)
        {
            var category=await _productcategoryService.AddProductCategoryAsync(productCategoryDTO).ConfigureAwait(false);

            return Ok(StoreResponse.GetStoreResponseModel(true, "200", "Kategori başarıyla eklendi.", category));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductCategory(ProductCategoryDTO productCategoryDTO)
        {
            var category = await _productcategoryService.UpdateCategoryAsync(productCategoryDTO).ConfigureAwait(false);

            return Ok(StoreResponse.GetStoreResponseModel(true, "200", "İstenen katagori başarıyla güncellendi", category));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            await _productcategoryService.DeleteProductCategoryAsync(id).ConfigureAwait(false);

            return Ok(StoreResponse.GetStoreResponseModel(true, "200", "İstenen kategori başarıyla silindi"));
        }
    }
}
