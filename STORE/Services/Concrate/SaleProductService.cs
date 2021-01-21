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
    public class SaleProductService : ISaleProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleProductRepository _saleProductRepository;

        public SaleProductService(IUnitOfWork unitOfWork)
        {
            _saleProductRepository = unitOfWork.SaleProducties;
            _unitOfWork = unitOfWork;
        }
        //public async Task<SoldProductDTO> AddSoldProductAsync(SoldProductDTO soldProductDTO)
        //{
        //    if (soldProductDTO == null)
        //        throw new StoreApiException("Bu ürün satılamaz.");

        //    var soldProducts = new SoldProduct
        //    {
        //        Id = soldProductDTO.Id,
        //        InsertedDate = soldProductDTO.InsertedDate,
        //        ProductId = soldProductDTO.ProductId,
        //        ReceiptId = soldProductDTO.ReceiptId,
        //        SaleAmount = soldProductDTO.SoldAmount,

        //    };-
        //    await _saleProductRepository.AddAsync(soldProducts).ConfigureAwait(false);
        //    await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
        //    return soldProductDTO;
        //}
    }
}
