using LinqKit;
using STORE.DTOs;
using STORE.ENTITY.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace STORE.Filter
{
    public class SaleFilter
    {
        [Required(ErrorMessage = "Barkod alanı boş bırakılamaz.")]
        public String Barcode { get; set; }
        public DateTime? LowDate { get; set; }
        public DateTime? TopDate { get; set; }
        //public int soldProductId { get; set; }
        //public SoldProduct SoldProduct { get; set; }

        public ExpressionStarter<SoldProduct> FilterEntities()
        {
            var predice = PredicateBuilder.New<SoldProduct>(p => p.Id > 0);

            predice = predice.And(p => p.Product.Barcode.Equals(Barcode));
            predice = predice.FilterDateTimes(TopDate, LowDate);

            return predice;
        }
    }
}
