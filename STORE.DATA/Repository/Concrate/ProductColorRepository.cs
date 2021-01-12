using STORE.DATA.Repository.Abstract;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Repository.Concrate
{
    public class ProductColorRepository:BaseRepository<ProductColor>,IProductColorRepository
    {
        public ProductColorRepository(StoreContext storeContext):base(storeContext)
        {
                
        }
    }
}
