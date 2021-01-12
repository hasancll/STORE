using STORE.DATA.Repository.Abstract;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Repository.Concrate
{
    public class ProductCategoryRepository:BaseRepository<ProductCategory>,IProductCategoryRepository
    {
        public ProductCategoryRepository(StoreContext storeContext) : base(storeContext) 
        {
        }
    }
}
