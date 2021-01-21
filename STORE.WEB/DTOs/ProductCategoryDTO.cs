//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class ProductCategoryDTO:BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //public IEnumerable<Product> Products { get; set; } 
    }
}
