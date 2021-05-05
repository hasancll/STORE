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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _companyService.GetAllProductCategoryAsync().ConfigureAwait(false);
            HttpContext.Items["message"] = "Kurum bilgileri getirildi.";
            return Ok(companies);
        }
        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyDTO companyDTO)
        {
            var company = await _companyService.AddProductCategoryAsync(companyDTO).ConfigureAwait(false);
            HttpContext.Items["message"] = "Kurum başarılı şekilde eklendi";
            return Ok(company);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCompany(CompanyDTO companyDTO)
        {
            var company = await _companyService.UpdateCategoryAsync(companyDTO).ConfigureAwait(false);
            HttpContext.Items["message"] = "Kurum bilgileri güncellendi.";
            return Ok(company);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCompany(int id)
        {
            var company = await _companyService.GetByIdCompany(id).ConfigureAwait(false);
            HttpContext.Items["message"] = "Kurum başarı bir şekilde getirildi";
            return Ok(company);
        }
        
    }
}
