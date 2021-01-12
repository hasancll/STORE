using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.DTOs
{
    public class ProductCategoryDTO:BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public IEnumerable<Product> Products { get; set; } böyle olacak galiba sor bakam
    }
}
