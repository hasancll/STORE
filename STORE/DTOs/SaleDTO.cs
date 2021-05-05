using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace STORE.DTOs
{
    public class SaleDTO
    {
        public List<SaleProductDTO> SaleProductDTOs { get; set; }

        [Range(0, 100)]
        public int DiscountPercent { get; set; }

        public ReceiptPaymentDTO ReceiptPaymentDTO { get; set; }
    }
}
