using STORE.DATA.Repository.Abstract;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Repository.Concrate
{
    public class ProductStockRepository:BaseRepository<ProductStock>,IProductStockRepository
    {
        public ProductStockRepository(StoreContext storeContext) : base(storeContext)
        {

        }
    }
}
