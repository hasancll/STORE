using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPaymentTypies()
        {
            var paymentTypies = await _paymentTypeService.GetAllPaymentTypeAsync().ConfigureAwait(false);
            HttpContext.Items["message"] = "Ödeme tipleri başarılı bir şekilde getirildi.";
            return Ok(paymentTypies);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToPymentType(int id)
        {
           await _paymentTypeService.DeletePaymentTypeAsync(id).ConfigureAwait(false);
            HttpContext.Items["message"] = "İstenilen gider başarılı bir şekilde silindi.";
            return Ok();
        }
    }
}
