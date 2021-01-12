using System.ComponentModel.DataAnnotations.Schema;

namespace STORE.ENTITY.Entities
{
    public class SoldProduct:BaseEntity
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public decimal SaleAmount { get; set; }
        [ForeignKey("Receipt")]
        public int ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
