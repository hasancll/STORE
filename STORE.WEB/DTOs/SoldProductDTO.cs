using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class SoldProductDTO:BaseDTO
    {
        public int ProductId { get; set; }
        public virtual ProductDTO ProductDTO { get; set; }
        public decimal SoldAmount { get; set; }
        public int ReceiptId { get; set; }
        public virtual ReceiptDTO ReceiptDTO { get; set; }
    }
}
