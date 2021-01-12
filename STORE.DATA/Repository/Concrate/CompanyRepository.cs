using STORE.DATA.Repository.Abstract;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Repository.Concrate
{
    public class CompanyRepository:BaseRepository<Company>,ICompanyRepository
    {
        public CompanyRepository(StoreContext storeContext) : base(storeContext) 
        {
        }
    }
}
