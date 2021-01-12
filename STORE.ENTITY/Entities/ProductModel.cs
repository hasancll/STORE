using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.ENTITY.Entities
{
    public class ProductModel : BaseEntity
    {
        public String Name { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
