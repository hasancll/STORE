using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace STORE.ENTITY.Entities
{
    public class Receipt : BaseEntity
    {
        [ForeignKey("ReceiptPayment")]
        public int ReceiptPaymentId { get; set; }
        public virtual ReceiptPayment ReceiptPayment { get; set; }
        public virtual IEnumerable<SoldProduct> SaleProducts { get; set; }

    }
}
