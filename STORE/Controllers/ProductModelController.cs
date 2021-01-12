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

            return Ok(StoreResponse.GetStoreResponseModel(true, "200", "Modeller başarıyla getirildi", models));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductModel(int id)
        {
            var model = await _productModelService.GetByIdProductModelAsync(id).ConfigureAwait(false);

            return Ok(StoreResponse.GetStoreResponseModel(true, "200", "İstenilen model başarıyla getirildi", model));
        }
        [HttpPost]
        public async Task<IActionResult> AddProductModel(ProductModelDTO productModelDTO)
        {
            var model = await _productModelService.AddProductModelAsync(productModelDTO).ConfigureAwait(false);

            return Ok(StoreResponse.GetStoreResponseModel(true, "200", "Model başarıyla eklendi", model));
        }
    }
}
