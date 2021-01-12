using System.ComponentModel.DataAnnotations.Schema;

namespace STORE.ENTITY.Entities
{
    public class ReceiptPayment : BaseEntity
    {
        [ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public decimal Card { get; set; }
        public decimal Cash { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
