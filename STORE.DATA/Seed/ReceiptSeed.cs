//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using STORE.ENTITY.Entities;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace STORE.DATA.Seed
//{
//    public class ReceiptSeed : IEntityTypeConfiguration<Receipt>
//    {
//        public void Configure(EntityTypeBuilder<Receipt> builder)
//        {
//            builder.HasData(GetSaleProducts());
//        }
//        private List<Receipt> GetSaleProducts()
//        {
//            var receipts = new List<Receipt>
//            {d
//                new Receipt
//                {
//                    Id = 1,
//                    InsertedDate = DateTime.Now,
//                    ReceiptPaymentId = 1,
//                    ReceiptPayment = new ReceiptPayment
//                    {
//                        Card = 27,
//                        Cash = 65,
//                        Id = 1,
//                        PaymentTypeId = 1,
//                        TotalPrice = 92,
//                        InsertedDate = DateTime.Now,
//                    },
//                    SaleProducts = new List<SoldProduct>
//                    {
//                        new SoldProduct
//                        {
//                            Id = 1,
//                            InsertedDate = new DateTime(2020,12,1,11,21,22),
//                            ProductId = 4,
//                            ReceiptId = 1,
//                            SaleAmount = 1,
//                        }
//                    }
//                }/*,
//                  new ENTITY.Entities.Receipt
//                {
//                    Id = 2,
//                    InsertedDate = DateTime.Now,
//                    ReceiptPaymentId = 2,
//                    ReceiptPayment = new ReceiptPayment
//                    {
//                        Card = 37,
//                        Cash = 65,
//                        Id = 2,
//                        PaymentTypeId = 1,
//                        TotalPrice = 102,
//                        InsertedDate = DateTime.Now,
//                    },
//                    SaleProducts = new List<SoldProduct>
//                    {
//                        new SoldProduct
//                        {
//                            Id = 2,
//                            InsertedDate = new DateTime(2020,12,3,11,21,22),
//                            ProductId = 6,
//                            ReceiptId = 2,
//                            SaleAmount = 2,
//                        }
//                    }
//                },
//                  new ENTITY.Entities.Receipt
//                {
//                    Id = 3,
//                    ReceiptPaymentId = 3,
//                    InsertedDate = DateTime.Now,
//                    ReceiptPayment = new ReceiptPayment
//                    {
//                        Card = 37,
//                        Cash = 103,
//                        Id = 3,
//                        PaymentTypeId = 1,
//                        TotalPrice = 140,
//                        InsertedDate = DateTime.Now,
//                    },
//                    SaleProducts = new List<SoldProduct>
//                    {
//                        new SoldProduct
//                        {
//                            Id = 3,
//                            InsertedDate =new DateTime(2020,12,3,11,21,22),
//                            ProductId = 4,
//                            ReceiptId = 2,
//                            SaleAmount = 2,
//                        }
//                    }
//                  },
//                  new ENTITY.Entities.Receipt
//                {
//                    Id = 4,
//                    ReceiptPaymentId = 4,
//                    InsertedDate = DateTime.Now,
//                    ReceiptPayment = new ReceiptPayment
//                    {
//                        Card = 90,
//                        Cash = 65,
//                        Id = 4,
//                        PaymentTypeId = 1,
//                        TotalPrice = 155,
//                        InsertedDate = DateTime.Now,
//                    },
//                    SaleProducts = new List<SoldProduct>
//                    {
//                        new SoldProduct
//                        {
//                            Id = 4,
//                            InsertedDate = new DateTime(2020,12,5,11,21,22),
//                            ProductId = 13,
//                            ReceiptId = 3,
//                            SaleAmount = 1
//                        }
//                    }
//                }*/

//            };

//            return receipts;
//        }
//    }
//}
