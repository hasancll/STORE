using STORE.DTOs;
using STORE.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Abstract
{
    public interface ISaleProductService
    {
        Task<ReceiptDTO> AddSoldProductAsync(SaleDTO saleDTO);

        Task<SoldProductDTO> GetFilteredSoldProducts(SaleFilter saleFilter);

    }
}
