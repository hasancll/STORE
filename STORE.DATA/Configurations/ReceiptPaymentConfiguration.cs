using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Configurations
{
    public class ReceiptPaymentConfiguration:BaseConfiguration<ReceiptPayment>
    {
        public override void Configure(EntityTypeBuilder<ReceiptPayment> builder)
        {
            builder.Property(r => r.Card).HasColumnType("decimal(18,2)");
            builder.Property(r => r.Cash).HasColumnType("decimal(18,2)");
            builder.Property(r => r.TotalPrice).HasColumnType("decimal(18,2)");
            base.Configure(builder);
        }
    }
}
