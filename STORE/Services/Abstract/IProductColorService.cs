using STORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Abstract
{
    public interface IProductColorService
    {
        Task<ProductColorDTO> AddProductColorAsync(ProductColorDTO productColorDTO);
        Task DeleteProductColorAsync(int productColorId);
        Task<List<ProductColorDTO>> GetAllProductColorAsync();
        Task<ProductColorDTO> GetByIdProductColorAsync(int productColorId);
        Task<ProductColorDTO> UpdateProductColorAsync(ProductColorDTO productColorDTO);
    }
}
