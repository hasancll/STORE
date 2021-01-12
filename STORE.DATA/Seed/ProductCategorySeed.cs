using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Seed
{
    public class ProductCategorySeed : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(GetProductCategory());
        }
        private List<ProductCategory> GetProductCategory()
        {
            var categories = new List<ProductCategory>
            { new ProductCategory
            {
                Id = 1,
                Description="asdasd",
                Name="Kadır",
                InsertedDate = DateTime.Now
            }
            };
            return categories;

        }

    }
}
