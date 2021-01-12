using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Seed
{
    public class ProductSizeSeed : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasData(GetProductSizes());
        }

        private List<ProductSize> GetProductSizes()
        {
            var sizes = new List<ProductSize>
            {
                 new ProductSize
                {
                    Id=1,
                    InsertedDate = DateTime.Now,
                    Name = "ExtraSmall"
                },

                new ProductSize
                {
                    Id=2,
                    InsertedDate = DateTime.Now,
                    Name = "Small"
                },
                new ProductSize
                {
                      Id=3,
                    InsertedDate = DateTime.Now,
                    Name = "Medium"
                },
                 new ProductSize
                {
                    Id=4,
                    InsertedDate = DateTime.Now,
                    Name = "Large"
                },
                  new ProductSize
                {
                    Id=5,
                    InsertedDate = DateTime.Now,
                    Name = "ExtraLarge"
                },
                   new ProductSize
                {
                    Id=6,
                    InsertedDate = DateTime.Now,
                    Name = "ExtraExtraLarge"
                },
                    new ProductSize
                {
                    Id=7,
                    InsertedDate = DateTime.Now,
                    Name = "3ExtraLarge"
                },
                     new ProductSize
                {
                    Id=8,
                    InsertedDate = DateTime.Now,
                    Name = "4ExtraLarge"
                },
                      new ProductSize
                {
                    Id=9,
                    InsertedDate = DateTime.Now,
                    Name = "5ExtraLarge"
                },
            };

            return sizes;
        }
    }
}
