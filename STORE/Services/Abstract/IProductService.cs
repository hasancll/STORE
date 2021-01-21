using STORE.DTOs;
using STORE.ENTITY.Includable.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Abstract
{
    public interface IProductService
    {
        Task<ProductDTO> AddProductAsync(ProductDTO productDTO);
        Task<ProductDTO> UpdateProductAsync(ProductDTO productDTO);
        Task DeleteProductAsync(int productId);
        Task<List<ProductDTO>> GetAllProductAsync();
        Task<ProductDTO> GetByIdProductAsync(int productId);
        Task<ProductDTO> GetByBarcodeProduct(string barcode);


    }
}
