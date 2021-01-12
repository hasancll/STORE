using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.DTOs
{
    public class ProductStockDTO:BaseDTO
    {
        public int StockAmount { get; set; }
        public Product Product { get; set; }
    }
}
