using STORE.DATA.Repository.Abstract;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Repository.Concrate
{
    public class ReceiptRepository: BaseRepository<Receipt>,IReceiptRepository
    {
        public ReceiptRepository(StoreContext storeContext):base(storeContext)
        {
                
        }
    }
}
