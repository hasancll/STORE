using STORE.DATA.Repository.Abstract;
using STORE.DTOs;
using STORE.ENTITY.Entities;
using STORE.ENTITY.Includable;
using STORE.EXCEPTION;
using STORE.Services.Abstract;
using STORE.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Concrate
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _productRepository = unitOfWork.Products;
            _unitOfWork = unitOfWork;
        }
        public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                throw new StoreApiException("Eksik yada hatalı bilgi girişi yaptınız");


            var products = new Product()
            {
                Barcode = productDTO.Barcode,
                ProductCode=productDTO.ProductCode,
                Description = productDTO.Description,
                InsertedDate = productDTO.InsertedDate,
                ProductCategoryId = productDTO.ProductCategoryId,
                ProductColorId = productDTO.ProductColorId,
                ProductModelId = productDTO.ProductModelId,
                ProductSizeId = productDTO.ProductSizeId,
                ProductStock=new ProductStock
                {
                    StockAmount=productDTO.ProductStockDTO.StockAmount
                },
                ProductStockId = productDTO.ProductStockId,
                ProfitPrice = productDTO.ProfitPrice,
                UnitPrice = productDTO.UnitPrice,
                PurchasePrice = productDTO.PurchasePrice,
            };

            await _productRepository.AddAsync(products).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return productDTO;
        }

        public async Task DeleteProductAsync(int productId)
        {
            if (productId <= 0)
                throw new StoreApiException("Silmek istediğiniz ürün bilgilerine erişilemedi");
            await _productRepository.DeleteAsync(productId).ConfigureAwait(false);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
        }

        public async Task<List<ProductDTO>> GetAllProductAsync()
        {
            var products = await _productRepository.GetAllAsync(p => p.Include(pc => pc.ProductCategory).Include(pr=>pr.ProductColor).Include(pm=>pm.ProductModel).Include(ps=>ps.ProductSize).Include(pso=>pso.ProductStock)).ConfigureAwait(false);

            if (products == null)
                throw new StoreApiException("Kayıtlı herhangi bir ürün bulunamadı");

            var productDTOs = products != null ?
                (from p in products
                 select new ProductDTO
                 {
                     Id = p.Id,
                     Barcode = p.Barcode,
                     ProductCode = p.ProductCode,
                     Description = p.Description,
                     InsertedDate = p.InsertedDate,
                     ProductCategoryId = p.ProductCategoryId,
                     ProductCategoryDTO = new ProductCategoryDTO
                     {
                         Name = p.ProductCategory.Name
                     },
                     ProductColorId = p.ProductColorId,
                     ProductColorDTO = new ProductColorDTO
                     {
                         Name=p.ProductColor.Name
                     },
                     ProductModelId = p.ProductModelId,
                     ProductModelDTO = new ProductModelDTO
                     {
                         Name=p.ProductModel.Name
                     },
                     ProductSizeId = p.ProductSizeId,
                     ProductSizeDTO = new ProductSizeDTO
                     {
                         Name=p.ProductSize.Name
                     },
                     ProductStockId = p.ProductStockId,
                     ProductStockDTO=new ProductStockDTO
                     {
                         StockAmount=p.ProductStock.StockAmount
                     },
                     ProfitPrice = p.ProfitPrice,
                     PurchasePrice = p.PurchasePrice,
                     UnitPrice = p.UnitPrice
                 }).ToList() : null;

            return productDTOs;
        }

        public async Task<ProductDTO> GetByBarcodeProduct(string barcode)
        {
            var product = await _productRepository.GetByBarcodeProduct(barcode).ConfigureAwait(false);
            if (product == null)
                throw new StoreApiException("Bu barkod numarasına göre ürün bulunamadı");
            var products = await _productRepository.GetByIdAsync(product.Id, p => p.Include(pc => pc.ProductCategory).Include(pr => pr.ProductColor).Include(pm => pm.ProductModel).Include(ps => ps.ProductSize).Include(pso => pso.ProductStock)).ConfigureAwait(false);
            
            var productDTO = new ProductDTO
            {
                Id = products.Id,
                Barcode = products.Barcode,
                Description = products.Description,
                InsertedDate = products.InsertedDate,
                ProductCode = products.ProductCode,
                ProductCategoryId = products.ProductCategoryId,
                ProductCategoryDTO = new ProductCategoryDTO
                {
                    Name = products.ProductCategory.Name
                },
                ProductColorId = products.ProductColorId,
                ProductColorDTO = new ProductColorDTO
                {
                    Name = product.ProductColor.Name
                },
                ProductModelId = products.ProductModelId,
                ProductModelDTO = new ProductModelDTO
                {
                    Name = products.ProductModel.Name
                },
                ProductSizeId = products.ProductSizeId,
                ProductSizeDTO = new ProductSizeDTO
                {
                    Name = products.ProductSize.Name
                },
                ProfitPrice = products.ProfitPrice,
                PurchasePrice = products.PurchasePrice,
                UnitPrice = products.UnitPrice,
                ProductStockId = products.ProductStockId,
                ProductStockDTO = new ProductStockDTO
                {
                    StockAmount = products.ProductStock.StockAmount
                }
                
            };
            //var products = await _productRepository.GetByIdAsync(productDTO.Id,p => p.Include(pc => pc.ProductCategory).Include(pr => pr.ProductColor).Include(pm => pm.ProductModel).Include(ps => ps.ProductSize).Include(pso => pso.ProductStock)).ConfigureAwait(false);
            //var _productDTO = new ProductDTO
            //{
            //    Id = products.Id,
            //    Barcode = products.Barcode,
            //    Description = products.Description,
            //    InsertedDate = products.InsertedDate,
            //    ProductCode = products.ProductCode,
            //    ProductCategoryId = products.ProductCategoryId,
            //    ProductCategoryDTO = new ProductCategoryDTO
            //    {
            //        Name = products.ProductCategory.Name
            //    },
            //    ProductColorId = products.ProductColorId,
            //    ProductColorDTO = new ProductColorDTO
            //    {
            //        Name = products.ProductColor.Name
            //    },
            //    ProductModelId = products.ProductModelId,
            //    ProductModelDTO = new ProductModelDTO
            //    {
            //        Name = products.ProductModel.Name
            //    },
            //    ProductSizeId = products.ProductSizeId,
            //    ProductSizeDTO = new ProductSizeDTO
            //    {
            //        Name = products.ProductSize.Name
            //    },
            //    ProfitPrice = products.ProfitPrice,
            //    PurchasePrice = products.PurchasePrice,
            //    UnitPrice = products.UnitPrice,
            //    ProductStockId = products.ProductStockId,
            //    ProductStockDTO = new ProductStockDTO
            //    {
            //        StockAmount = products.ProductStock.StockAmount
            //    }

            //};
            return productDTO;
        }

        public async Task<ProductDTO> GetByIdProductAsync(int productId)
        {
            var products = await _productRepository.GetByIdAsync(productId,p => p.Include(pc => pc.ProductCategory).Include(pr => pr.ProductColor).Include(pm => pm.ProductModel).Include(ps => ps.ProductSize).Include(pso => pso.ProductStock)).ConfigureAwait(false);
            if (products == null)
                throw new StoreApiException("Görüntülenmek istenen ürün bilgilerine ulaşılamadı");
            var productDTOs = new ProductDTO
            {
                Id = products.Id,
                Barcode = products.Barcode,
                Description = products.Description,
                InsertedDate = products.InsertedDate,
                ProductCode = products.ProductCode,
                ProductCategoryId = products.ProductCategoryId,
                ProductCategoryDTO = new ProductCategoryDTO
                {
                    Name = products.ProductCategory.Name
                },
                ProductColorId = products.ProductColorId,
                ProductColorDTO = new ProductColorDTO
                {
                    Name = products.ProductColor.Name
                },
                ProductModelId = products.ProductModelId,
                ProductModelDTO = new ProductModelDTO
                {
                    Name = products.ProductModel.Name
                },
                ProductSizeId = products.ProductSizeId,
                ProductSizeDTO = new ProductSizeDTO
                {
                    Name = products.ProductSize.Name
                },
                ProfitPrice = products.ProfitPrice,
                PurchasePrice = products.PurchasePrice,
                UnitPrice = products.UnitPrice,
                ProductStockId = products.ProductStockId,
                ProductStockDTO = new ProductStockDTO
                {
                    StockAmount = products.ProductStock.StockAmount
                }

            };

            //var products = await _productRepository.GetByIdAsync(productId,x=>x.Include(ps=>ps.ProductStock)).ConfigureAwait(false);
            //TODO includeları unutma.
            /* var productDTOs = new ProductDTO
             {
                 Id = products.Id,
                 Barcode = products.Barcode,
                 ProductCode = products.ProductCode,
                 Description = products.Description,               
                 InsertedDate = products.InsertedDate,
                 ProductCategoryId = products.ProductCategoryId,
                 ProductCategoryDTO = new ProductCategoryDTO
                 {
                     Name=products.ProductCategory.Name
                 },
                 ProductColorId = products.ProductColorId,
                 ProductColorDTO=new ProductColorDTO
                 {
                     Name=products.ProductCategory.Name
                 },
                 ProductModelId = products.ProductModelId,
                 ProductModelDTO=new ProductModelDTO
                 {
                     Name=products.ProductModel.Name
                 },
                 ProductSizeId = products.ProductSizeId,
                 ProductStockId = products.ProductStockId,
                 ProfitPrice = products.ProfitPrice,
                 PurchasePrice = products.PurchasePrice,
                 UnitPrice = products.UnitPrice
             };*/

            return productDTOs;
        }

       

        public async Task<ProductDTO> UpdateProductAsync(ProductDTO productDTO)
        {
            
            var product = await _productRepository.GetByIdAsync(productDTO.Id, x => x.Include(ps => ps.ProductStock)).ConfigureAwait(false);
            if (product == null)
                throw new StoreApiException("Geçersiz ya da hatalı bilgi girişi yaptınız");
            /* var products = new Product
             {
                 Id = productDTO.Id,
                 Barcode = productDTO.Barcode,
                 ProductCode = productDTO.ProductCode,
                 Description = productDTO.Description,
                 InsertedDate = productDTO.InsertedDate,
                 ProductCategoryId = productDTO.ProductCategoryId,
                 ProductColorId = productDTO.ProductColorId,
                 ProductModelId = productDTO.ProductModelId,
                 ProductSizeId = productDTO.ProductSizeId,
                 ProfitPrice = productDTO.ProfitPrice,
                 PurchasePrice = productDTO.PurchasePrice,
                 UnitPrice = productDTO.UnitPrice
             };*/
            product.Barcode = productDTO.Barcode;
            product.Description = productDTO.Description;
            product.ProductCategoryId = productDTO.ProductCategoryId;
            product.ProductColorId = productDTO.ProductColorId;
            product.ProductModelId = productDTO.ProductModelId;
            product.ProductSizeId = productDTO.ProductSizeId;
            product.ProductCode = productDTO.ProductCode;
            product.ProfitPrice = productDTO.ProfitPrice;
            product.PurchasePrice = product.PurchasePrice;
            product.UnitPrice = product.UnitPrice;
            product.ProductStock.StockAmount = productDTO.ProductStockDTO.StockAmount;

            _productRepository.Update(product);
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);

            return productDTO;
        }
    }
}
