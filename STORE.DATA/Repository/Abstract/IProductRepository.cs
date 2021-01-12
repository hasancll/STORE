using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STORE.DATA.Repository.Abstract
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByBarcodeProduct(String barcode);
    }
}
