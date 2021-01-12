using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Configurations
{
    public class ProductStockConfiguration : BaseConfiguration<ProductStock>
    {
        public override void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.Property(p => p.StockAmount).HasColumnType("decimal(18,2)");

            base.Configure(builder);
        }
    }
}
