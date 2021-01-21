using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using STORE.WEB.ApiService;
using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly ProductCategoryService _productCategoryService;
        private readonly IMapper _mapper;
        public ProductCategoryController(ProductCategoryService productCategoryService,IMapper mapper)
        {
            _productCategoryService = productCategoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var ProductCategory = await _productCategoryService.GetAllAsync().ConfigureAwait(false);

            return View(_mapper.Map<List<ProductCategoryDTO>>(ProductCategory));
        }
    }
}
