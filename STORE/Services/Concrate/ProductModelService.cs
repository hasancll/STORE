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
    public class ProductModelService : IProductModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductModelRepository _productModelRepository;
        public ProductModelService(IUnitOfWork unitOfWork)
        {
            _productModelRepository = unitOfWork.ProductModels;
            _unitOfWork = unitOfWork;
        }
        public async Task<ProductModelDTO> AddProductModelAsync(ProductModelDTO productModelDTO)
        {
            var productModels = new ProductModel
            {
                Id = productModelDTO.Id,
                InsertedDate = productModelDTO.InsertedDate,
                Name = productModelDTO.Name,

            };
            await _productModelRepository.AddAsync(productModels).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return productModelDTO;
        }

        public async Task DeleteProductModelAsync(int productModelId)
        {
            await _productModelRepository.DeleteAsync(productModelId).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
        }

        public async Task<List<ProductModelDTO>> GetAllProductModelAsync()
        {
            var productModels = await _productModelRepository.GetAllAsync().ConfigureAwait(false);

            var productDTOs = productModels != null ?
                (from p in productModels
                 select new ProductModelDTO
                 {
                     Id = p.Id,
                     InsertedDate = p.InsertedDate,
                     Name = p.Name
                 }
                ).ToList() : null;

            return productDTOs;
        }

        public async Task<ProductModelDTO> GetByIdProductModelAsync(int productModelId)
        {
            var productModels = await _productModelRepository.GetByIdAsync(productModelId).ConfigureAwait(false);

            var productModelDTOs = new ProductModelDTO
            {
                Id = productModels.Id,
                InsertedDate = productModels.InsertedDate,
                Name = productModels.Name
            };

            return productModelDTOs;
        }

        public async Task<ProductModelDTO> UpdateProductModelAsync(ProductModelDTO productModelDTO)
        {
            var models = await _productModelRepository.GetByIdAsync(productModelDTO.Id).ConfigureAwait(false);

            if (models == null)
                throw new StoreApiException("Güncellenmek istenen model bulunamadı");
            models.Name = productModelDTO.Name;

            _productModelRepository.Update(models);

            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);

            return productModelDTO;
            
        }
    }
}
