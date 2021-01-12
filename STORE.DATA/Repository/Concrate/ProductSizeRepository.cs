using STORE.DATA.Repository.Abstract;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Repository.Concrate
{
    public class ProductSizeRepository:BaseRepository<ProductSize>,IProductSizeRepository
    {
        public ProductSizeRepository(StoreContext storeContext) :base(storeContext)
        {

        }
    }
}
