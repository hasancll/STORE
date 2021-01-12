using STORE.DATA.Repository.Abstract;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Repository.Concrate
{
    public class ExpenseRepository:BaseRepository<Expense>,IExpenseRepository
    {
        public ExpenseRepository(StoreContext storeContext) : base(storeContext)
        {
        }

    }
}
