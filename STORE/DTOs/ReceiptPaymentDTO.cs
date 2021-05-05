using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.DTOs
{
    public class ReceiptPaymentDTO:BaseDTO
    {
        public int PaymentTypeId { get; set; }
        public virtual PaymentTypeDTO PaymentTypeDTO { get; set; }
        public decimal Card { get; set; }
        public decimal Cash { get; set; }
    }
}
