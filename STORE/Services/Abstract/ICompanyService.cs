using STORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Abstract
{
    public interface ICompanyService
    {
        Task<CompanyDTO > AddProductCategoryAsync(CompanyDTO companyDTO);
        Task<CompanyDTO> UpdateCategoryAsync(CompanyDTO companyDTO);
        Task<List<CompanyDTO>> GetAllProductCategoryAsync();
    }
}
