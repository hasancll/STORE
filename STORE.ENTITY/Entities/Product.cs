using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace STORE.ENTITY.Entities
{
    public class Product : BaseEntity
    {
        public String Barcode { get; set; }
        public String ProductCode { get; set; }
        public String Description { get; set; }
        public Decimal PurchasePrice { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal ProfitPrice { get; set; }

        [ForeignKey("ProductModel")]
        public int ProductModelId { get; set; }
        public virtual ProductModel ProductModel { get; set; }

        [ForeignKey("ProductStock")]
        public int ProductStockId { get; set; }
        public virtual ProductStock ProductStock { get; set; }
        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        [ForeignKey("ProductColor")]
        public int ProductColorId { get; set; }
        public virtual ProductColor ProductColor { get; set; }
        [ForeignKey("ProductSize")]
        public int ProductSizeId { get; set; }
        public virtual ProductSize ProductSize { get; set; }

        public virtual SoldProduct SoldProduct { get; set; }

    }
}
