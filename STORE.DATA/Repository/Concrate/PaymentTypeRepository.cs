using STORE.DATA.Repository.Abstract;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Repository.Concrate
{
    public class PaymentTypeRepository:BaseRepository<PaymentType>,IPaymentTypeRepository
    {
        public PaymentTypeRepository(StoreContext storeContext) : base(storeContext) 
        {
        }
    }
}
