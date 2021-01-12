using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Configurations
{
    public class ProductCategoryConfiguratiom:BaseConfiguration<ProductCategory>
    {
        public ProductCategoryConfiguratiom(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(pc => pc.Name).IsRequired();
        }
    }
}
