using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.ENTITY.Entities
{
    public class ProductStock : BaseEntity
    {
        public int StockAmount { get; set; }
        public virtual Product Product { get; set; }
    }
}
