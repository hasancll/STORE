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
    public class ProductColorService : IProductColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductColorRepository _productColorRepository;
        public ProductColorService(IUnitOfWork unitOfWork)
        {
            _productColorRepository = unitOfWork.ProductColors;
            _unitOfWork = unitOfWork;
        }
        public async Task<ProductColorDTO> AddProductColorAsync(ProductColorDTO productColorDTO)
        {
            if (productColorDTO == null)
                throw new StoreApiException("Eksik ya da hatalı bilgi girişi yaptınız");
            var productColors = new ProductColor
            {
                InsertedDate = productColorDTO.InsertedDate,
                Name = productColorDTO.Name,

            };

            await _productColorRepository.AddAsync(productColors).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return productColorDTO;
        }

        public async Task DeleteProductColorAsync(int productColorId)
        {
            if (productColorId <= 0)
                throw new StoreApiException("İstenilen renk bilgisine ulaşılamadı");
            await _productColorRepository.DeleteAsync(productColorId).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
        }

        public async Task<List<ProductColorDTO>> GetAllProductColorAsync()
        {
            var productColors = await _productColorRepository.GetAllAsync().ConfigureAwait(false);
            if (productColors == null)
                throw new StoreApiException("Kayıtlı herhangi bir renk bulunamadı");
            var productColorDTOs = productColors != null ?
                (from p in productColors
                 select new ProductColorDTO
                 {
                     InsertedDate = p.InsertedDate,
                     Name = p.Name,
                     Id = p.Id
                 }
                ).ToList() : null;

            return productColorDTOs;
                
        }

        public async Task<ProductColorDTO> GetByIdProductColorAsync(int productColorId)
        {
            var productColors = await _productColorRepository.GetByIdAsync(productColorId).ConfigureAwait(false);
            if (productColors == null)
                throw new StoreApiException("İstenilen renk bilgilerine erişilemedi");
            var productColorDTOs = new ProductColorDTO
            {
                Id = productColors.Id,
                InsertedDate = productColors.InsertedDate,
                Name = productColors.Name
            };
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return productColorDTOs;
               
        }

        public async Task<ProductColorDTO> UpdateProductColorAsync(ProductColorDTO productColorDTO)
        {
            var colors = await _productColorRepository.GetByIdAsync(productColorDTO.Id).ConfigureAwait(false);
            
            if (colors == null)
                throw new StoreApiException("Güncellenmek istenen renk bulunamadı.");

            colors.Name = productColorDTO.Name;

            _productColorRepository.Update(colors);

            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);

            return productColorDTO;
        }
    }
}
