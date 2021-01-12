using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Configurations
{
    public class ProductColorConfiguration:BaseConfiguration<ProductColor>
    {
        public ProductColorConfiguration(EntityTypeBuilder<ProductColor> builder)
        {
            builder.Property(pc => pc.Name).IsRequired();
        }
    }
}
