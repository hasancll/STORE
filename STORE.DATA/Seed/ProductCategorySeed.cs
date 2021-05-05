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
                Description="Bu kategoriye ürün eklemesi yapılacaktır.",
                Name="Kadın",
                InsertedDate = DateTime.Now
            },
            new ProductCategory
            {
                Id=2,
                Description="Bu kategori iptal edilebilir",
                InsertedDate=DateTime.Now,
                Name="Erkek"
            },
            new ProductCategory
            {
                Id=3,
                Description="Bu kategori güncellenecektir.",
                InsertedDate=DateTime.Now,
                Name="Kız Çocuk"
            },
            new ProductCategory
            {
                Id=4,
                Description="Bu kategoride çeşit artırılmalıdır.",
                InsertedDate=DateTime.Now,
                Name="Erkek Çocuk"
            },

            };
            return categories;

        }

    }
}
