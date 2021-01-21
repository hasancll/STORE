using STORE.DATA.Repository.Abstract;
using STORE.DTOs;
using STORE.ENTITY.Entities;
using STORE.EXCEPTION;
using STORE.Services.Abstract;
using STORE.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Concrate
{
   
    public class ProductSizeService : IProductSizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductSizeRepository _productSizeRepository;

        public ProductSizeService(IUnitOfWork unitOfWork)
        {
            _productSizeRepository = unitOfWork.ProductSizes;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductSizeDTO> AddProductSizeAsync(ProductSizeDTO productSizeDTO)
        {
            if (productSizeDTO == null)
                throw new StoreApiException("Eksik yada hatalı bilgi girişi yaptınız");
            var productSize = new ProductSize
            {
                Name = productSizeDTO.Name
                
            };

            await _productSizeRepository.AddAsync(productSize).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return productSizeDTO;
        }

        public async Task DeleteProductSizeAsync(int productSizeId)
        {
            if (productSizeId <= 0)
                throw new StoreApiException("Silmek istedğiniz beden bilgisine erişilemedi");
            await _productSizeRepository.DeleteAsync(productSizeId).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
        }

        public async Task<List<ProductSizeDTO>> GetAllProductSizesAsync()
        {
            var productSizes = await _productSizeRepository.GetAllAsync().ConfigureAwait(false);
            if (productSizes == null)
                throw new StoreApiException("Kayıtlı herhangi bir beden bulunamadı");
            var productSizeDTOs = productSizes != null ?
                                  (from ps in productSizes
                                   select new ProductSizeDTO
                                   {
                                       Id = ps.Id,
                                       InsertedDate = ps.InsertedDate,
                                        Name = ps.Name
                                   }).ToList() : null;

            return productSizeDTOs;
        }

        public async Task<ProductSizeDTO> GetByIdProductSizeAsync(int productSizeId)
        {
            var productSize = await _productSizeRepository.GetByIdAsync(productSizeId).ConfigureAwait(false);
            if (productSize == null)
                throw new StoreApiException("İstenilen beden bilgisine erişilemedi");
            var productSizeDTO = new ProductSizeDTO
            {
                Id = productSize.Id,
                Name = productSize.Name,
                InsertedDate = productSize.InsertedDate
            };

            return productSizeDTO;

        }

        public async Task<ProductSizeDTO> UpdateProcductSizezAsync(ProductSizeDTO productSizeDTO)
        {
            var size = await _productSizeRepository.GetByIdAsync(productSizeDTO.Id).ConfigureAwait(false);
            if (size == null)
                throw new StoreApiException("Güncellenmek istenen bedene erişilemedi");
            size.Name = productSizeDTO.Name;
           /* var productSize = new ProductSize
            {
                Name = productSizeDTO.Name,
                InsertedDate=productSizeDTO.InsertedDate
            };
           */
            _productSizeRepository.Update(size);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return productSizeDTO;
        }
    }
}
