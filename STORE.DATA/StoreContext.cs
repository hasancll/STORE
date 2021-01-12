using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using STORE.DATA.Configurations;
using STORE.DATA.Seed;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA
{
    public class StoreContext : IdentityDbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        //Burayı Danış
        #region Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductStockConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseIncomesConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptPaymentConfiguration());
            modelBuilder.ApplyConfiguration(new SaleProductConfiguration());

            #region Seed's
            modelBuilder.ApplyConfiguration(new ProductSizeSeed());
            modelBuilder.ApplyConfiguration(new ProductCategorySeed());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region DbSet's
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpensesIncomes> ExpensesIncomes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptPayment> ReceiptPayments { get; set; }
        public DbSet<SoldProduct> SaleProducts { get; set; }

        #endregion
    }
}
