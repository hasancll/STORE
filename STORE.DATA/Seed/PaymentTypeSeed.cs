using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Seed
{
    public class PaymentTypeSeed : IEntityTypeConfiguration<ENTITY.Entities.PaymentType>
    {
        public void Configure(EntityTypeBuilder<ENTITY.Entities.PaymentType> builder)
        {
            builder.HasData(GetPaymentTypies());
        }
        private List<ENTITY.Entities.PaymentType> GetPaymentTypies()
        {
            var payment = new List<PaymentType>
            {
                new PaymentType
                {
                    Id=1,
                    Name="Kredi Kartı",
                    InsertedDate=DateTime.Now
                },
                new PaymentType
                {
                    Id=2,
                    Name="Nakit",
                    InsertedDate=DateTime.Now
                }
            };
            return payment;
            
        }
    }
    
}
