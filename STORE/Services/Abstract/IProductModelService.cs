using STORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Abstract
{
    public interface IProductModelService
    {
        Task<ProductModelDTO> AddProductModelAsync(ProductModelDTO productModelDTO);
        Task DeleteProductModelAsync(int productModelId);
        Task<List<ProductModelDTO>> GetAllProductModelAsync();
        Task<ProductModelDTO> GetByIdProductModelAsync(int productModelId);
        Task<ProductModelDTO> UpdateProductModelAsync(ProductModelDTO productModelDTO);
    }
}
