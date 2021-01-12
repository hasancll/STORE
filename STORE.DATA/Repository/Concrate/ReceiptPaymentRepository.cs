using STORE.DATA.Repository.Abstract;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Repository.Concrate
{
    public class ReceiptPaymentRepository: BaseRepository<ReceiptPayment>, IReceiptPaymentRepository
    {
        public ReceiptPaymentRepository(StoreContext storeContext):base(storeContext)
        {
                
        }
    }
}
