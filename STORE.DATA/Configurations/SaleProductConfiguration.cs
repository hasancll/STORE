using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Configurations
{
    public class SaleProductConfiguration:BaseConfiguration<SoldProduct>
    {
        public override void Configure(EntityTypeBuilder<SoldProduct> builder)
        {
            builder.Property(s => s.SaleAmount).HasColumnType("decimal(18,2)");
            base.Configure(builder);
        }
    }
}
