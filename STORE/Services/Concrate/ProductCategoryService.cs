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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _productCategoryRepository = unitOfWork.ProductCategories;
            _unitOfWork = unitOfWork;
        }
        public async Task<ProductCategoryDTO> AddProductCategoryAsync(ProductCategoryDTO productCategoryDTO)
        {
            if (productCategoryDTO == null)
                throw new StoreApiException("Eklenecek katergori bilgilerine erişilemedi.");

            var productCategory = new ProductCategory
            {
                Name = productCategoryDTO.Name,
                Description = productCategoryDTO.Description,
            };
            await _productCategoryRepository.AddAsync(productCategory).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return productCategoryDTO;
        }

        public async Task DeleteProductCategoryAsync(int productCategoryId)
        {
            if (productCategoryId <= 0)
                throw new StoreApiException("Geçersiz bir işlem yaptınız");
            await _productCategoryRepository.DeleteAsync(productCategoryId).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
        }

        public async Task<List<ProductCategoryDTO>> GetAllProductCategoryAsync()
        {
            var productCategories = await _productCategoryRepository.GetAllAsync().ConfigureAwait(false);

            if(productCategories == null)
                throw new StoreApiException("Kayıtlı hiçbir kategori bulunamadı.");
            

            var productCategoryDTOs = productCategories != null ?
                (from pc in productCategories
                 select new ProductCategoryDTO
                 {
                     Id = pc.Id,
                     Description = pc.Description,
                     InsertedDate = pc.InsertedDate,
                     Name = pc.Name
                 }
                 ).ToList() : null;


            return productCategoryDTOs;
        }

        public async Task<ProductCategoryDTO> GetByIdProductCategoryAsync(int productCategoryId)
        {
            var productCategories = await _productCategoryRepository.GetByIdAsync(productCategoryId).ConfigureAwait(false);

            if (productCategories == null)
                throw new StoreApiException("Görüntülenmek istenen kategori bilgilerine ulaşılamadı.");

            var productCategoriesDTOs = new ProductCategoryDTO
            {
                Id = productCategories.Id,
                Description = productCategories.Description,
                InsertedDate = productCategories.InsertedDate,
                Name = productCategories.Name
            };

            return productCategoriesDTOs;
        }

        public async Task<ProductCategoryDTO> UpdateCategoryAsync(ProductCategoryDTO productCategoryDTO)
        {
            var category = await _productCategoryRepository.GetByIdAsync(productCategoryDTO.Id).ConfigureAwait(false);

            if (category == null)
                throw new StoreApiException("Güncellenmek istenen kategori bulunamadı.");

            category.Description = productCategoryDTO.Description;
            category.Name = productCategoryDTO.Name;

            _productCategoryRepository.Update(category);

            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);//Buraya dikkat

            return productCategoryDTO;
        }
    }
}
