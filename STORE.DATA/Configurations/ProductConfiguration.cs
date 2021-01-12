using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Configurations
{
    public class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PurchasePrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.ProfitPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.UnitPrice).IsRequired();
            builder.Property(p => p.PurchasePrice).IsRequired();
            builder.Property(p => p.ProfitPrice).IsRequired();
            builder.Property(p => p.Barcode).IsRequired();
            builder.Property(p => p.ProductCode).IsRequired();
            builder.HasIndex(p => p.Barcode).IsUnique();

            base.Configure(builder);
        }
    }
}
