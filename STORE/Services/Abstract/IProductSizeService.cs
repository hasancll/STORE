using STORE.DTOs;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Abstract
{
    public interface IProductSizeService
    {
        Task<ProductSizeDTO> AddProductSizeAsync(ProductSizeDTO productSizeDTO);
        Task<ProductSizeDTO> UpdateProcductSizezAsync(ProductSizeDTO productSizeDTO);
        Task DeleteProductSizeAsync(int productSizeId);
        Task<List<ProductSizeDTO>> GetAllProductSizesAsync();
        Task<ProductSizeDTO> GetByIdProductSizeAsync(int productSizeId);
    }
}
