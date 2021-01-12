using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.DATA.Configurations
{
    class ExpenseConfiguration:BaseConfiguration<Expense>
    {
        public override void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(e => e.ExpenseAmount).HasColumnType("decimal(18,2)");
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Description).IsRequired();

            base.Configure(builder);
        }
    }
}
