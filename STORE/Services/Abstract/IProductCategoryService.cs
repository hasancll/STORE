using STORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Abstract
{
    public interface IProductCategoryService
    {
        Task<ProductCategoryDTO> AddProductCategoryAsync(ProductCategoryDTO productCategoryDTO);
        Task<ProductCategoryDTO> UpdateCategoryAsync(ProductCategoryDTO productCategoryDTO);
        Task DeleteProductCategoryAsync(int productCategoryId);
        Task<List<ProductCategoryDTO>> GetAllProductCategoryAsync();
        Task<ProductCategoryDTO> GetByIdProductCategoryAsync(int productCategoryId);
    }
}
