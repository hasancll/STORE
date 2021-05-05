using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Seed
{
    public class ProductColorSeed:IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.HasData(GetProductColor());
        }
        private List<ProductColor> GetProductColor()
        {
            var colors = new List<ProductColor>
            { new ProductColor
            {
                Id = 1,
                Name="Kırmızı",
                InsertedDate = DateTime.Now
            },
            new ProductColor
            {
                Id=2,
                Name="Sarı",
                InsertedDate=DateTime.Now
            },
            new ProductColor
            {
                Id=3,
                Name="Pembe",
                InsertedDate=DateTime.Now
            },
            new ProductColor
            {
                Id=4,
                Name="Turuncu",
                InsertedDate=DateTime.Now
            },
            new ProductColor
            {
                Id=5,
                Name="Lila",
                InsertedDate=DateTime.Now
            }

        };

            return colors;
        }
    }
}
