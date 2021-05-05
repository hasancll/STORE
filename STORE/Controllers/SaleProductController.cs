using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STORE.DTOs;
using STORE.Filter;
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
    public class SaleProductController : ControllerBase
    {
        private readonly ISaleProductService _saleProductService;
        public SaleProductController(ISaleProductService saleProductService)
        {
            saleProductService = _saleProductService;
        }
        [HttpPost]
        public async Task<IActionResult> GetFilteredSoldProducts(SaleFilter saleFilter)
        {
            var product = await _saleProductService.GetFilteredSoldProducts(saleFilter).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen ürün istatistikleri bir şekilde getirildi.";
            return Ok(product);
        }
    }
}
