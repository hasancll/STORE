using STORE.DATA.Repository.Abstract;
using STORE.DTOs;
using STORE.ENTITY.Entities;
using STORE.ENTITY.Includable;
using STORE.EXCEPTION;
using STORE.Filter;
using STORE.Services.Abstract;
using STORE.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Concrate
{
    public class SaleProductService : ISaleProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IReceiptRepository _receiptRepository;

        public SaleProductService(IUnitOfWork unitOfWork)
        {
            _saleProductRepository = unitOfWork.SaleProducties;
            _productRepository = unitOfWork.Products;
            _unitOfWork = unitOfWork;
        }

        public async Task<ReceiptDTO> AddSoldProductAsync(SaleDTO saleDTO)
        {
            if (saleDTO.SaleProductDTOs == null)
                throw new StoreApiException("Satış için en az bir ürün girmelisiniz");

            var products = (await _productRepository.GetAllAsync(p => saleDTO.SaleProductDTOs.Select(p => p.ProductId).Contains(p.Id), p => p.Include(p => p.ProductStock)).ConfigureAwait(false)).ToList();

            products.ForEach(p =>
            {
                saleDTO.SaleProductDTOs.ForEach(sp =>
                {
                    if (sp.ProductId.Equals(p.Id))
                    {
                        if (sp.SaleAmount > p.ProductStock.StockAmount)
                            throw new StoreApiException(p.Description + " adlı ürüne ait stok miktarı bu satış için yeterli değildir.");

                        p.ProductStock.StockAmount -= sp.SaleAmount;
                    }
                });
            });

            var totalAmount = products.Select(p => p.UnitPrice).Sum();
            var discountedTotalAmount = totalAmount - (totalAmount * saleDTO.DiscountPercent / 100);

            if (saleDTO.ReceiptPaymentDTO.Cash + saleDTO.ReceiptPaymentDTO.Card != discountedTotalAmount)
                throw new StoreApiException($"Bu satış için gerekli tutar : {discountedTotalAmount}");

            _productRepository.UpdateRange(products);

            var receipt = new Receipt
            {
                ReceiptPayment = new ReceiptPayment

                {
                    Card = saleDTO.ReceiptPaymentDTO.Card,
                    Cash = saleDTO.ReceiptPaymentDTO.Cash,
                    TotalPrice = discountedTotalAmount,
                    PaymentTypeId = saleDTO.ReceiptPaymentDTO.PaymentTypeId
                },
                SaleProducts = (from sp in saleDTO.SaleProductDTOs
                                select new SoldProduct
                                {
                                    ProductId = sp.ProductId,
                                    SaleAmount = sp.SaleAmount
                                }).ToList()
            };

            await _receiptRepository.AddAsync(receipt).ConfigureAwait(false);

            var receiptDTO = new ReceiptDTO
            {
                InsertedDate = receipt.InsertedDate,
                Id = receipt.Id,
                ReceiptPaymentDTO = new ReceiptPaymentDTO
                {
                    Card = receipt.ReceiptPayment.Card,
                    Cash = receipt.ReceiptPayment.Cash,
                    PaymentTypeId = receipt.ReceiptPayment.PaymentTypeId
                },
                SoldProductDTO = from sp in receipt.SaleProducts
                                 select new SoldProductDTO
                                 {
                                     ProductId = sp.ProductId,
                                     SoldAmount = sp.SaleAmount
                                 }
            };

            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);

            return receiptDTO;
        }

        public async Task<SoldProductDTO> GetFilteredSoldProducts(SaleFilter saleFilter)
        {
            var soldProducts = await _saleProductRepository.GetAllAsync(saleFilter?.FilterEntities(), p => p.Include(p => p.Product)).ConfigureAwait(false);

            if (soldProducts == null) throw new StoreApiException("Girdiğiz tarih arasında satış olmamıştır.");

            var soldProduct = new SoldProductDTO
            {
                ProductDTO = new ProductDTO
                {
                    Description = soldProducts.First().Product.Description
                },
                SoldAmount = soldProducts.Sum(p => p.SaleAmount),
                ProductId = soldProducts.First().ProductId,
            };
       
            return soldProduct;
        }
    }
}
